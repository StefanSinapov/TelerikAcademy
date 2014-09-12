package com.team.blaze.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.sql.Statement;

public class DAO
{
    protected PreparedStatement prepareStatement(Connection connection, String sql, boolean returnGeneratedKeys, Object... values) throws SQLException
    {
        PreparedStatement preparedStatement = connection.prepareStatement(sql, returnGeneratedKeys ? Statement.RETURN_GENERATED_KEYS : Statement.NO_GENERATED_KEYS);
        setValues(preparedStatement, values);

        return preparedStatement;
    }

    protected void setValues(PreparedStatement preparedStatement, Object... values) throws SQLException
    {
        int count = values.length;

        for (int i = 0; i < count; i++)
        {
            preparedStatement.setObject(i + 1, values[i]);
        }
    }
}
