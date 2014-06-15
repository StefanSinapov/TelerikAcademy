package com.team.blaze.dao;

import com.team.blaze.exceptions.ExceptionLogger;
import com.team.blaze.models.Player;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class ScoreDAOJDBC extends DAO implements ScoreDAO
{
    private final DAOFactory daoFactory;
    private final String SQL_INSERT_PLAYER = "INSERT INTO player (player.id, player.name, player.score) VALUES (?, ?, ?)";
    private final String SQL_LIST_ALL_PLAYERS = "SELECT * FROM player ORDER BY player.score DESC, player.name LIMIT 0,10";
    private final String SQL_DELETE_PLAYER = "DELETE FROM player WHERE player.id = ?";

    public ScoreDAOJDBC(DAOFactory daoFactory)
    {
        this.daoFactory = daoFactory;
    }

    private Player mapPlayer(ResultSet resultSet) throws SQLException
    {
        long id = resultSet.getLong("player.id");
        String name = resultSet.getString("player.name");
        int score = resultSet.getInt("player.score");

        return new Player(id, score, name);

    }

    @Override
    public void createPlayer(Player player)
    {
        Object[] values =
        {

        };

        try (Connection connection = daoFactory.getConnection())
        {
            try (PreparedStatement preparedStatement = prepareStatement(connection, SQL_INSERT_PLAYER, true, values))
            {
                int affectedRows = preparedStatement.executeUpdate();

                if (affectedRows == 0)
                {
                    throw new SQLException("Creating player failed, no rows affected.");
                }

                try (ResultSet resultSet = preparedStatement.getGeneratedKeys())
                {
                    if (resultSet.next())
                    {
                        player.setPlayerId(resultSet.getLong(1));
                    }
                    else
                    {
                        throw new SQLException("Creating player failed, no generated key obtained.");
                    }
                }
            }
        }
        catch (SQLException exception)
        {
            ExceptionLogger.Log(exception);
        }
    }

    @Override
    public void deletePlayer(Player player)
    {
        Object[] values =
        {
            player.getPlayerId()
        };

        try (Connection connection = daoFactory.getConnection())
        {
            try (PreparedStatement preparedStatement = prepareStatement(connection, SQL_DELETE_PLAYER, false, values))
            {
                int affectedRows = preparedStatement.executeUpdate();
                if (affectedRows == 0)
                {
                    throw new SQLException("Deleting play failed, no rows affected.");
                }
                else
                {
                    player = null;
                }
            }
        }
        catch (SQLException exception)
        {
            ExceptionLogger.Log(exception);
        }
    }

    @Override
    public List<Player> listAllPlayers()
    {
        List<Player> players = new ArrayList<>();

        try (Connection connection = daoFactory.getConnection())
        {
            try (PreparedStatement preparedStatement = connection.prepareStatement(SQL_LIST_ALL_PLAYERS))
            {
                try (ResultSet resultSet = preparedStatement.executeQuery())
                {
                    while (resultSet.next())
                    {
                        players.add(mapPlayer(resultSet));
                    }
                }
            }
        }
        catch (SQLException e)
        {
            ExceptionLogger.Log(e);
        }

        return players;
    }
}
