package com.team.blaze.dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

class DriverManagerDAOFactory extends DAOFactory
{
    private final String url;
    private final String login;
    private final String password;

    DriverManagerDAOFactory(String url, String login, String password)
    {
        this.url = url;
        this.login = login;
        this.password = password;
    }

    @Override
    public Connection getConnection() throws SQLException
    {
        return DriverManager.getConnection(url, login, password);
    }

}
