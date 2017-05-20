package bg.tusofia.structures;

import java.util.ArrayList;

public class CheckForFreeOfficeStructure {
    private String status = "";

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    private String city = "";
    private String dtm = "";
    private ArrayList<String[]> offices = null;

    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }

    public String getDtm() {
        return dtm;
    }

    public void setDtm(String dtm) {
        this.dtm = dtm;
    }

    public ArrayList<String[]> getOffices() {
        return offices;
    }

    public void setOffices(ArrayList<String[]> offices) {
        this.offices = offices;
    }

    public CheckForFreeOfficeStructure(){
        offices = new ArrayList<String[]>();

    }

    public void addOffice(String name, String id){
        offices.add(new String[]{name, id});
    }

    public void removeOffice(String name){
        for (int i = 0; i < offices.size(); i++) {
            if (offices.get(i)[0].equalsIgnoreCase(name)){
                offices.remove(i);
            }
        }
    }
}
