package bg.tusofia;

import bg.tusofia.generalfunctionality.LogManager;
import bg.tusofia.generalfunctionality.MySQLConnector;

import java.util.LinkedList;

public class Params extends Thread{

    private LinkedList<MySQLConnector> dbPool;

    private String httpsrvPort = "";

    public String getHttpsrvPort() {
        return httpsrvPort;
    }

    public void setHttpsrvPort(String httpsrvPort) {
        this.httpsrvPort = httpsrvPort;
    }

    public LogManager log = null;

    public void createLogManager(String filename) {
        log = new LogManager(filename);
    }

    private String dbIP = "";
    private String dbPort = "";
    private String dbUsername = "";
    private String dbPassword = "";
    private String dbDB = "";
    private int dbPoolSize = 10;

    public int getDbPoolSize() {
        return dbPoolSize;
    }

    public void setDbPoolSize(int dbPoolSize) {
        this.dbPoolSize = dbPoolSize;
    }

    public String getDbIP() {
        return dbIP;
    }

    public void setDbIP(String dbIP) {
        this.dbIP = dbIP;
    }

    public String getDbPort() {
        return dbPort;
    }

    public void setDbPort(String dbPort) {
        this.dbPort = dbPort;
    }

    public String getDbUsername() {
        return dbUsername;
    }

    public void setDbUsername(String dbUsername) {
        this.dbUsername = dbUsername;
    }

    public String getDbPassword() {
        return dbPassword;
    }

    public void setDbPassword(String dbPassword) {
        this.dbPassword = dbPassword;
    }

    public String getDbDB() {
        return dbDB;
    }

    public void setDbDB(String dbDB) {
        this.dbDB = dbDB;
    }

    public Params() {
        dbPool = new LinkedList<MySQLConnector>();
    }

    public synchronized MySQLConnector getDBConnection(){
        MySQLConnector connector = null;
        try {
            while (connector == null){
                if (dbPool.size()> 1){
                    connector = dbPool.poll();
                }else {
                     sleep(100);
                }
            }
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        return connector;
    }

    public void run(){
        try {
            while (true) {
                if (dbPool.size() < dbPoolSize){
                    MySQLConnector connector = new MySQLConnector(getDbIP(), getDbPort(), getDbDB(), getDbUsername(), getDbPassword(), log);
                    connector.connectToDB();
                    dbPool.add(connector);
                }
                sleep(20);
            }
        } catch (Exception e){

        }
    }

}


