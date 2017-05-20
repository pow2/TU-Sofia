package bg.tusofia.HTTPServ;

import bg.tusofia.DBHandler;
import bg.tusofia.DEBUG;
import bg.tusofia.Params;
import bg.tusofia.generalfunctionality.JsonConvertor;
import bg.tusofia.structures.CitiesStructure;
import com.sun.net.httpserver.HttpExchange;
import com.sun.net.httpserver.HttpHandler;
import java.io.IOException;

public class AppointmentOneHandler implements HttpHandler {
    private Params params;

    public AppointmentOneHandler(Params params) {
        this.params = params;
    }

    @Override
    public void handle(HttpExchange he) throws IOException {
        String request = RootHandler.getRequestMessage(he);
        params.log.log(this, "Info: " + request);
        String response = processRequest(request);
        RootHandler.sendResponseMessage(he, response);
        params.log.log(this, "Info: " + response);
    }

    private String processRequest (String request){
        String response = "";
        try {
            CitiesStructure str = null;
            str = JsonConvertor.fromJson(request, CitiesStructure.class);
            str.setCities(DBHandler.getCitiesWithOffices(params));
            str.setStatus("OK");
            response = JsonConvertor.toJson(str);
        }
        catch (Exception e){
            params.log.log(this, "Error: " + e.getMessage());
        }
        return response;
    }
}