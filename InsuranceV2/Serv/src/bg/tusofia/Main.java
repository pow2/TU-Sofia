package bg.tusofia;

import bg.tusofia.HTTPServ.HttpServ;

public class Main {

    public static void main(String[] args) {
        Params params = LoadParams.LoadFromFile();
        params.createLogManager("");
        // Fire the db pool
        try {
            Thread t = new Thread(params);
            t.start();
            params.log.log(Main.class.getClass().getName(), "Info: " + "DB connection pool started.");
            // Fire the HTTP server
            HttpServ http = new HttpServ(params);
        } catch (Exception e){
            params.log.log(Main.class.getClass().getName(), "Error: " + e.getMessage());
        }
    }
}
