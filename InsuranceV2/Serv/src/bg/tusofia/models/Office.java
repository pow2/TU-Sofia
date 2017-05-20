package bg.tusofia.models;

public class Office {
    private String officeName;
    private String officeId;
    private String city;

    public Office() {
    }

    public Office(String officeName, String officeId, String city) {
        this.officeName = officeName;
        this.officeId = officeId;
        this.city = city;
    }

    public String getOfficeName() {
        return officeName;
    }

    public void setOfficeName(String officeName) {
        this.officeName = officeName;
    }

    public String getOfficeId() {
        return officeId;
    }

    public void setOfficeId(String officeId) {
        this.officeId = officeId;
    }

    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }
}