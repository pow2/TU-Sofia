package bg.tusofia.models;

public class VehPriceInfo {
    private String price;
    private String dateend;
    private String vehcategory;
    private String vehcapacity;
    private String citycategory;
    private String vehicle;

    public VehPriceInfo() {
    }

    public VehPriceInfo(String price, String dateend, String vehcategory, String vehcapacity, String citycategory, String vehicle) {
        this.price = price;
        this.dateend = dateend;
        this.vehcategory = vehcategory;
        this.vehcapacity = vehcapacity;
        this.citycategory = citycategory;
        this.vehicle = vehicle;
    }

    public String getPrice() {
        return price;
    }

    public void setPrice(String price) {
        this.price = price;
    }

    public String getDateend() {
        return dateend;
    }

    public void setDateend(String dateend) {
        this.dateend = dateend;
    }

    public String getVehcategory() {
        return vehcategory;
    }

    public void setVehcategory(String vehcategory) {
        this.vehcategory = vehcategory;
    }

    public String getVehcapacity() {
        return vehcapacity;
    }

    public void setVehcapacity(String vehcapacity) {
        this.vehcapacity = vehcapacity;
    }

    public String getCitycategory() {
        return citycategory;
    }

    public void setCitycategory(String citycategory) {
        this.citycategory = citycategory;
    }

    public String getVehicle() {
        return vehicle;
    }

    public void setVehicle(String vehicle) {
        this.vehicle = vehicle;
    }
}
