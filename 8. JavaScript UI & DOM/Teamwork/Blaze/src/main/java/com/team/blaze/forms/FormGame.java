package com.team.blaze.forms;

import com.team.blaze.dao.DAOFactory;
import com.team.blaze.dao.ScoreDAO;
import com.team.blaze.models.ConnectionType;
import com.team.blaze.models.Player;
import java.io.Serializable;
import java.util.List;
import javax.enterprise.context.RequestScoped;
import javax.inject.Named;

@Named(value = "formGame")
@RequestScoped
public class FormGame implements Serializable
{
    private static final long serialVersionUID = 1L;
    private final DAOFactory dao;
    private final ScoreDAO scoreDAO;

    private String formHiddenInput;

    public FormGame()
    {
        this.dao = DAOFactory.getInstance(ConnectionType.Default);
        this.scoreDAO = dao.getScoreDAO();

    }

    public void loadScores()
    {
        List<Player> players = scoreDAO.listAllPlayers();

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < players.size(); i++)
        {
            sb.append(players.get(i).getPlayerId());
            sb.append(',');
            sb.append(players.get(i).getName());
            sb.append(',');
            sb.append(players.get(i).getScore());

            if (i < players.size() - 1)
            {
                sb.append(',');
            }
        }

        System.out.println("Log Scores: " + sb.toString());
        this.formHiddenInput = sb.toString();

    }

    public String getFormHiddenInput()
    {
        return formHiddenInput;
    }

    public void setFormHiddenInput(String formHiddenInput)
    {
        this.formHiddenInput = formHiddenInput;
    }

    public void saveScores()
    {
        System.out.println("Need to be implemeted.");
        System.out.println("Saving " + this.formHiddenInput);
        /*
         List<Player> list = new ArrayList<>();

         String[] splitted = this.formHiddenInput.split(",");

         Player player;
         Player newplayer = null;
         Player deletePlayer = null;
         for (int i = 0; i < splitted.length; i = i + 3)
         {
         long id = Long.parseLong(splitted[i]);

         String name = splitted[i + 1];
         int score = Integer.parseInt(splitted[i + 2]);
         if (id == 11)
         {
         newplayer = new Player(id, score, name);
         }
         player = new Player(id, score, name);
         list.add(player);
         }
         // find missing player.

         scoreDAO.deletePlayer(deletePlayer);
         scoreDAO.createPlayer(newplayer);*/

    }

}
