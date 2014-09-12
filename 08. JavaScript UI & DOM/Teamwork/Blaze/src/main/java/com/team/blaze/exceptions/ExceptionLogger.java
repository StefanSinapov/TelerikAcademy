package com.team.blaze.exceptions;

public final class ExceptionLogger
{
    public static void Log(Exception exception)
    {
        StackTraceElement[] stackTraceElements = Thread.currentThread().getStackTrace();
        String methodName = stackTraceElements[2].getMethodName();
        String className = stackTraceElements[2].getClassName();
        System.err.println("Called in - Class: " + className + " Method: " + methodName);
        System.err.println(exception.getMessage());
        System.err.println(exception);
    }
}
