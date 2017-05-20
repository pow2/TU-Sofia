package bg.tusofia;

import javafx.beans.binding.IntegerBinding;
import org.ini4j.Wini;

import java.io.File;

public class LoadParams {

    private static String DATABASE = "DATABASE";
    private static String HTTPSERVER = "HTTPSERVER";

    public LoadParams() {
    }

    public static Params LoadFromFile(){
        return LoadFromFile("");
    }

    public static Params LoadFromFile(String fileName) {

        Params params = new Params();
        params.createLogManager("");

        if (fileName.isEmpty()){
            try {
                fileName = "Serv.cfg";
            }
            catch (Exception e){
                params.log.log(e.getMessage());
            }
        }
        try {
            File config = new File(fileName);
            Wini ini = new Wini(config);
            params.setHttpsrvPort(ini.get(HTTPSERVER, "PORT"));
            params.setDbIP(ini.get(DATABASE, "IP"));
            params.setDbPort(ini.get(DATABASE, "PORT"));
            params.setDbUsername(ini.get(DATABASE, "USERNAME"));
            params.setDbPassword(ini.get(DATABASE, "PASSWORD"));
            params.setDbDB(ini.get(DATABASE, "DB"));
            params.setDbPoolSize(Integer.parseInt(ini.get(DATABASE, "POOL")));
        }
        catch (Exception e) {
            params = null;
            e.printStackTrace();
        }

        return params;
    }
}
