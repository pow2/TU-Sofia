package bg.tusofia.HTTPServ;

import bg.tusofia.DBHandler;
import bg.tusofia.DEBUG;
import bg.tusofia.Params;
import bg.tusofia.generalfunctionality.*;
import bg.tusofia.structures.CheckIfActiveStructure;
import com.sun.net.httpserver.HttpExchange;
import com.sun.net.httpserver.HttpHandler;

import java.io.IOException;

public class CheckifactiveHandler implements HttpHandler {
    private Params params;

    public CheckifactiveHandler(Params params) {
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
            CheckIfActiveStructure str = null;
            str = JsonConvertor.fromJson(request, CheckIfActiveStructure.class);
            if (SanityCheck.noEsc(str.getNumber())){
                str.setDate(DBHandler.getInsuranceEndDate(str.getNumber(), params));
                str.setStatus("Bad data");
                response = JsonConvertor.toJson(str);
                return response;
            }
            str.setDate(DBHandler.getInsuranceEndDate(str.getNumber(), params));
            str.setStatus("OK");
            response = JsonConvertor.toJson(str);
        }
        catch (Exception e){
            params.log.log(this, "Error: " +  e.getMessage());
        }
        return response;
    }
}
