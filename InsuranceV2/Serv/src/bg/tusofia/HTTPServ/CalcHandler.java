package bg.tusofia.HTTPServ;

import bg.tusofia.DBHandler;
import bg.tusofia.DEBUG;
import bg.tusofia.Params;
import bg.tusofia.generalfunctionality.*;
import bg.tusofia.models.VehPriceInfo;
import bg.tusofia.structures.CalcStructure;
import com.sun.net.httpserver.HttpExchange;
import com.sun.net.httpserver.HttpHandler;

import java.io.IOException;

public class CalcHandler implements HttpHandler {
    private Params params;

    public CalcHandler(Params params) {
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
            CalcStructure str = null;
            str = JsonConvertor.fromJson(request, CalcStructure.class);
            if (!SanityCheck.noEsc(str.getCity()) && !SanityCheck.noEsc(str.getCapacity())  && !SanityCheck.noEsc(str.getVehicle())){
                str.setStatus("Bad data");
                response = JsonConvertor.toJson(str);
                return response;
            }
            VehPriceInfo vehPriceInfo = DBHandler.getVehicleInfo(str.getVehicle(), str.getCapacity(), str.getCity(), params);
            str.setSum(vehPriceInfo.getPrice());
            str.setStatus("OK");
            response = JsonConvertor.toJson(str);
        }
        catch (Exception e){
            params.log.log(this, "Error: " +  e.getMessage());
        }
        return response;
    }
}