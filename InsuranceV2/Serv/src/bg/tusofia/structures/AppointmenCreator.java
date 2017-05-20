package bg.tusofia.structures;

import java.util.ArrayList;

public class AppointmenCreator{
    private String applicationID;
    private String officeId;
    private String dtm;
    private String status;
    private ArrayList<String> allAppointments;

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getApplicationID() {
        return applicationID;
    }

    public void setApplicationID(String applicationID) {
        this.applicationID = applicationID;
    }

    public String getOfficeId() {
        return officeId;
    }

    public void setOfficeId(String officeId) {
        this.officeId = officeId;
    }

    public String getDtm() {
        return dtm;
    }

    public void setDtm(String dtm) {
        this.dtm = dtm;
    }

    public ArrayList<String> getAllAppointments() {
        return allAppointments;
    }

    public void setAllAppointments(ArrayList<String> allAppointments) {
        this.allAppointments = allAppointments;
    }
}
