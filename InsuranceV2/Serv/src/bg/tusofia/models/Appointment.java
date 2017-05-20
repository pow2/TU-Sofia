package bg.tusofia.models;

public class Appointment {
    private String officeId;
    private String officeAddress;
    private String city;
    private String dTM;
    private String app;

    public String getOfficeId() {
        return officeId;
    }

    public void setOfficeId(String officeId) {
        this.officeId = officeId;
    }

    public String getOfficeAddress() {
        return officeAddress;
    }

    public void setOfficeAddress(String officeAddress) {
        this.officeAddress = officeAddress;
    }

    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }

    public String getdTM() {
        return dTM;
    }

    public void setdTM(String dTM) {
        this.dTM = dTM;
    }

    public String getApp() {
        return app;
    }

    public void setApp(String app) {
        this.app = app;
    }
}
