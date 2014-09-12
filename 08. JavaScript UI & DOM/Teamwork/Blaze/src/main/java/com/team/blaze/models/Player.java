package com.team.blaze.models;

public final class Player
{
    private Long playerId;
    private Integer score;
    private String name;

    public Player(Integer score, String name)
    {
        this(null, score, name);
    }

    public Player(Long playerId, Integer score, String name)
    {
        this.playerId = playerId;
        this.score = score;
        this.name = name;
    }

    public Long getPlayerId()
    {
        return this.playerId;
    }

    public void setPlayerId(Long playerId)
    {
        this.playerId = playerId;
    }

    public Integer getScore()
    {
        return this.score;
    }

    public void setScore(Integer score)
    {
        if (this.score == null)
        {
            throw new IllegalArgumentException("The score cannot be null.");
        }

        if (this.score < 0)
        {
            throw new IllegalArgumentException("The score cannot be less than 0.");
        }

        this.score = score;
    }

    public String getName()
    {
        return this.name;
    }

    public void setName(String name)
    {
        if (name == null || name.equals(""))
        {
            throw new IllegalArgumentException("The name cannot be null.");
        }

        this.name = name;
    }

}
