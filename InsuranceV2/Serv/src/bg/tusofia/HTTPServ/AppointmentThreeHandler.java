package bg.tusofia.HTTPServ;

import bg.tusofia.DBHandler;
import bg.tusofia.DEBUG;
import bg.tusofia.Params;
import bg.tusofia.generalfunctionality.JsonConvertor;
import bg.tusofia.generalfunctionality.TimeConversion;
import bg.tusofia.models.Appointment;
import bg.tusofia.models.Office;
import bg.tusofia.structures.AppointmenCreator;
import com.sun.net.httpserver.HttpExchange;
import com.sun.net.httpserver.HttpHandler;

import java.io.IOException;
import java.util.ArrayList;

public class AppointmentThreeHandler implements HttpHandler {
    private Params params;

    public AppointmentThreeHandler(Params params) {
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

    private String processRequest(String request) {
        String response = "";
        try {
            AppointmenCreator str = null;
            str = JsonConvertor.fromJson(request, AppointmenCreator.class);
            String dtm = str.getDtm();
            String officeId = str.getOfficeId();
            String applicationId = str.getApplicationID();
            ArrayList<Appointment> aList = DBHandler.createAppointment(applicationId, officeId, dtm, params);
            ArrayList<String> strList = new ArrayList<String>();
            if (aList != null) {
                int lSize = aList.size();
                for (int i = 0; i < lSize; i++) {
                    Appointment app = aList.get(i);
                    strList.add(TimeConversion.tsToShortTime(app.getdTM()) + ", " + app.getOfficeAddress() + ", " + app.getCity());
                }
            }
            str.setAllAppointments(strList);
            str.setStatus("OK");
            response = JsonConvertor.toJson(str);
        } catch (Exception e) {
            params.log.log(this, "Error: " + e.getMessage());
        }
        return response;
    }
}