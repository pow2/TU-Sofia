package bg.tusofia.generalfunctionality;

import java.sql.*;

public class MySQLConnector {
    static private final String JDBC_DRIVER = "com.mysql.jdbc.Driver";
    private String dbURL = "";
    private String host = "";
    private String port = "";
    private String databaseName = "";
    private String username = "";
    private String password = "";
    private Connection conn = null;
    private Statement stmt = null;
    private LogManager lMngr = null;
    //
    public MySQLConnector(String host, String port, String databaseName, String username, String password) {
        this.host = host;
        this.port = port;
        this.username = username;
        this.password = password;
        this.databaseName = databaseName;
        dbURL = dbURLGenerator();
    }

    public MySQLConnector(String host, String port, String databaseName, String username, String password, LogManager lMngr) {
        this.host = host;
        this.port = port;
        this.username = username;
        this.password = password;
        this.databaseName = databaseName;
        this.lMngr = lMngr;
        dbURL = dbURLGenerator();
    }

    private String dbURLGenerator() {
        String res;
        if (databaseName.isEmpty()) {
           res = "jdbc:mysql://" + host + ":" + port;
        }
        else {
           res = "jdbc:mysql://" + host + ":" + port + "/" + databaseName + "?user=" + username + "&password=" + password + "&useUnicode=true&characterEncoding=UTF-8&useSSL=false";
        }
        return res;
    }

    public boolean connectToDB() {
        boolean isThereAnError = false;
        try {
            Class.forName(JDBC_DRIVER).newInstance();
            conn = DriverManager.getConnection(dbURL);
            conn.setAutoCommit(false);
        }
        catch(SQLException se){
            isThereAnError = true;
            if (lMngr != null){
                lMngr.log(this.getClass().toString(), se.getMessage());
            }
            else {
                se.printStackTrace();
            }
        }
        catch(Exception e){
            isThereAnError = true;
            if (lMngr != null){
                lMngr.log(this.getClass().toString(), e.getMessage());
            }
            else {
                e.printStackTrace();
            }
        }
        finally{
            if (isThereAnError) {
                closeTheConnection();
            }
        }
        return !isThereAnError;
    }

    public boolean createStatement() {
        boolean isThereAnError = false;
        try {
            if (conn != null){
                stmt = conn.createStatement();
            }
        }
        catch(SQLException se){
            isThereAnError = true;
            if (lMngr != null){
                lMngr.log(this.getClass().toString(), se.getMessage());
            }
            else {
                se.printStackTrace();
            }
        }
        catch(Exception e){
            isThereAnError = true;
            if (lMngr != null){
                lMngr.log(this.getClass().toString(), e.getMessage());
            }
            else {
                e.printStackTrace();
            }
        }
        finally{
            if (isThereAnError) {
                closeTheConnection();
            }
        }
        return !isThereAnError;
    }

    public boolean closeStatement(){
        boolean isThereAnError = false;
        try {
            if (stmt != null) {
                stmt.close();
            }
        }
        catch (SQLException se2) {
            isThereAnError = true;
            if (lMngr != null){
                lMngr.log(this.getClass().toString(), se2.getMessage());
            }
            else {
                se2.printStackTrace();
            }
        }
        finally {
            stmt = null;
        }
        return !isThereAnError;
    }

    public boolean closeTheConnection(){
        boolean isThereAnError = false;
        try {
            if (stmt != null) {
                stmt.close();
            }
        }
        catch (SQLException se2) {
            isThereAnError = true;
            if (lMngr != null){
                lMngr.log(this.getClass().toString(), se2.getMessage());
            }
            else {
                se2.printStackTrace();
            }
        }
        catch (Exception e2) {
            isThereAnError = true;
            if (lMngr != null){
                lMngr.log(this.getClass().toString(), e2.getMessage());
            }
            else {
                e2.printStackTrace();
            }
        }
        finally {
            stmt = null;
        }
        try {
            if (conn != null) {
                conn.close();
            }
        }
        catch (SQLException se) {
            isThereAnError = true;
            if (lMngr != null){
                lMngr.log(this.getClass().toString(), se.getMessage());
            }
            else {
                se.printStackTrace();
            }
        }
        catch (Exception e) {
            isThereAnError = true;
            if (lMngr != null){
                lMngr.log(this.getClass().toString(), e.getMessage());
            }
            else {
                e.printStackTrace();
            }
        }
        finally {
            conn = null;
        }
        return !isThereAnError;
    }

    public ResultSet executeQuery(String sqlquery){
        ResultSet resSet = null;
        try
        {
            if (stmt != null){
                resSet = stmt.executeQuery(sqlquery);
            }
        }
        catch (SQLException se) {
            if (resSet != null){
                try{
                    resSet.close();
                }
                catch (SQLException se1){
                    if (lMngr != null){
                        lMngr.log(this.getClass().toString(), se1.getMessage());
                    }
                    else {
                        se1.printStackTrace();
                    }
                }
                finally {
                    resSet = null;
                }
            }
            if (lMngr != null){
                lMngr.log(this.getClass().toString(), se.getMessage());
            }
            else {
                se.printStackTrace();
            }
        }
        return resSet;
    }

    public int executeUpdate(String sqlquery){
        int res = 0;
        try
        {
            if (stmt != null) {
                res = stmt.executeUpdate(sqlquery);
            }
        }
        catch (Exception e){
            res = 0;
            if (lMngr != null){
                lMngr.log(this.getClass().toString(), e.getMessage());
            }
            else {
                e.printStackTrace();
            }
        }
        return res;
    }

    public PreparedStatement prepareStatement (String sqlquery){
        PreparedStatement prepStmt = null;
        try {
            prepStmt = conn.prepareStatement(sqlquery);
        }
        catch (Exception e){
            if (prepStmt != null){
                try {
                    prepStmt.close();
                }
                catch (SQLException se) {
                    if (lMngr != null){
                        lMngr.log(this.getClass().toString(), se.getMessage());
                    }
                    else {
                        se.printStackTrace();
                    }
                }
            }
            prepStmt = null;
            if (lMngr != null){
                lMngr.log(this.getClass().toString(), e.getMessage());
            }
            else {
                e.printStackTrace();
            }
        }
        return prepStmt;
    }

    public boolean commit(){
        boolean isThereAnEror = false;
        try {
            conn.commit();
        }
        catch (SQLException se){
            isThereAnEror = true;
            if (lMngr != null){
                lMngr.log(this.getClass().toString(), se.getMessage());
            }
            else {
                se.printStackTrace();
            }
        }
        return !isThereAnEror;
    }
}
