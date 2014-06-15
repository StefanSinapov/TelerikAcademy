package com.team.blaze.dao;

import com.team.blaze.models.Player;
import java.util.List;

public interface ScoreDAO
{
    public void createPlayer(Player player);

    public void deletePlayer(Player player);

    public List<Player> listAllPlayers();

}
