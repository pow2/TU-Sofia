package bg.tusofia.structures;

import java.util.ArrayList;

public class CitiesStructure {
    private ArrayList<String> cities;
    private String status = "";

    public void setStatus(String status) {
        this.status = status;
    }

    public void setCities(ArrayList<String> cities) {
        this.cities = cities;
    }

    public String getStatus() {

        return status;
    }

    public CitiesStructure() {
        cities = new ArrayList<String>();
    }

    public void addCity(String name){
        cities.add(name);
    }

    public void removeCity(String name){
        for (int i = 0; i < cities.size(); i++) {
            if (cities.get(i).equalsIgnoreCase(name)){
                cities.remove(i);
            }
        }
    }

    public ArrayList<String> getCities(){
        return cities;
    }

}
