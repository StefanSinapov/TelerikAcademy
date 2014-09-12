package com.team.blaze.dao;

import java.sql.Connection;
import java.sql.SQLException;
import javax.sql.DataSource;

class DataSourceDAOFactory extends DAOFactory
{
    private final DataSource dataSource;

    DataSourceDAOFactory(DataSource dataSource)
    {
        this.dataSource = dataSource;
    }

    @Override
    public Connection getConnection() throws SQLException
    {
        return dataSource.getConnection();
    }
}
