package com.team.blaze.dao;

import com.team.blaze.models.ConnectionType;
import java.sql.Connection;
import java.sql.SQLException;
import javax.naming.InitialContext;
import javax.naming.NamingException;
import javax.sql.DataSource;

public abstract class DAOFactory
{
    private static final String SQL_URL = "jdbc:mysql://localhost:3306/blaze";
    private static final String SQL_LOGIN = "";
    private static final String SQL_PASSWORD = "";
    private static final String DATABASE = "jdbc/blaze";

    public static DAOFactory getInstance(ConnectionType connectionType)
    {
        DAOFactory instance;

        switch (connectionType)
        {
            case JDBC:
            {
                instance = new DriverManagerDAOFactory(SQL_URL, SQL_LOGIN, SQL_PASSWORD);
                break;
            }
            case JDNI:
            default:
            {
                DataSource dataSource = null;

                try
                {
                    dataSource = (DataSource) new InitialContext().lookup(DATABASE);
                }
                catch (NamingException exception)
                {
                    System.err.println("Database name does not exist. " + exception.getMessage());
                }

                instance = new DataSourceDAOFactory(dataSource);
                break;
            }

        }

        return instance;
    }

    public abstract Connection getConnection() throws SQLException;

    public ScoreDAO getScoreDAO()
    {
        return new ScoreDAOJDBC(this);
    }

}
