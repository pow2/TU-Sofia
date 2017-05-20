package bg.tusofia.HTTPServ;

import bg.tusofia.DBHandler;
import bg.tusofia.DEBUG;
import bg.tusofia.Params;
import bg.tusofia.generalfunctionality.JsonConvertor;
import bg.tusofia.models.Office;
import bg.tusofia.structures.CheckForFreeOfficeStructure;
import com.sun.net.httpserver.HttpExchange;
import com.sun.net.httpserver.HttpHandler;

import java.io.IOException;
import java.util.ArrayList;

public class AppointmentTwoHandler implements HttpHandler {
    private Params params;

    public AppointmentTwoHandler(Params params) {
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
            CheckForFreeOfficeStructure str = null;
            str = JsonConvertor.fromJson(request, CheckForFreeOfficeStructure.class);
            String city = str.getCity();
            String startDtm = str.getDtm();
            ArrayList<Office> aList = DBHandler.getCityOfficesWithFreePlaces(city, startDtm, params);
            if (aList != null)
            {
                int lSize = aList.size();
                for (int i = 0; i < lSize; i++) {
                    Office off = aList.get(i);
                    str.addOffice(off.getOfficeName(), off.getOfficeId());
                }
            }
            str.setStatus("OK");
            response = JsonConvertor.toJson(str);
        }
        catch (Exception e){
            params.log.log(this, e.getMessage());
        }
        return response;
    }
}