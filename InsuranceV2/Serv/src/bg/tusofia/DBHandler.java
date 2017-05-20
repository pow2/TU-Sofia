package bg.tusofia;

import bg.tusofia.generalfunctionality.SanityCheck;
import bg.tusofia.models.Appointment;
import bg.tusofia.models.Office;
import bg.tusofia.generalfunctionality.MySQLConnector;
import bg.tusofia.generalfunctionality.TimeConversion;
import bg.tusofia.models.VehPriceInfo;

import java.math.BigInteger;
import java.security.MessageDigest;
import java.sql.ResultSet;
import java.util.ArrayList;

public class DBHandler {
    public static ArrayList<Office> getCityOfficesWithFreePlaces(String city, String startDtm, Params params){
        ArrayList<Office> aList = new ArrayList<Office>();
        if (!SanityCheck.noEsc(city) && !SanityCheck.noEsc(startDtm)){
            return  aList;
        }
        long stDtm = Long.parseLong(startDtm);
        long endDtm = stDtm + 3000000;
        MySQLConnector connector = params.getDBConnection();// new MySQLConnector(params.getDbIP(), params.getDbPort(), params.getDbDB(), params.getDbUsername(), params.getDbPassword());
        //connector.connectToDB();
        connector.createStatement();
        String query = "SELECT DISTINCT concat( off.address, ', ',ci.city) as office, off.id\n" +
                "FROM cities ci \n" +
                "INNER JOIN offices off \n" +
                "ON ci.id = off.city \n" +
                "LEFT JOIN appointments app\n" +
                "ON off.id = app.office\n" +
                "WHERE ci.city = '" + city.trim() + "'\n" +
                "AND (SELECT COUNT(*) FROM appointments app WHERE app.office = off.id and app.datetime between " + stDtm + " and " + endDtm + ") < off.capacity\n" +
                "ORDER BY off.id ASC";
        ResultSet rs = connector.executeQuery(query);
        try{
            if (rs != null)
            {
                while (rs.next())
                {
                    String name = rs. getString("office");
                    String id = Long.toString(rs.getLong("id"));
                    Office mOff = new Office(name, id, city);
                    aList.add(mOff);
                }
                rs.close();
            }
        } catch (Exception e){
            params.log.log(DBHandler.class, "Error: " + e.getMessage());
        }
        connector.closeStatement();
        connector.closeTheConnection();
        return aList;
    }

    public static  ArrayList<String> getCitiesWithOffices(Params params){
        ArrayList<String> aList = new ArrayList<String>();
        MySQLConnector connector = params.getDBConnection();
        connector.createStatement();
        String query = "SELECT DISTINCT ci.city FROM cities ci INNER JOIN offices off ON ci.id = off.city ORDER BY ci.category ASC";

        ResultSet rs =  connector.executeQuery(query);
        if (rs != null)
        {
            try{
               while(rs.next())
               {
                   aList.add(rs.getString("city"));
               }
               rs.close();
            } catch (Exception e){
                params.log.log(DBHandler.class, "Error: " + e.getMessage());
            }
        }
        connector.closeStatement();
        connector.closeTheConnection();
        return aList;
    }

    private static String randomVal(){
        String randomVal = TimeConversion.getCurrentTimestamp() + Math.random() + Thread.currentThread().toString();
        try {
            MessageDigest md = MessageDigest.getInstance("SHA-256");
            md.update(randomVal.getBytes("UTF-8")); // Change this to "UTF-16" if needed
            byte[] digest = md.digest();
            BigInteger bigInt = new BigInteger(1, digest);
            randomVal = bigInt.toString(16);
        }
        catch (Exception e){
        }
        return randomVal;
    }

    public static String getNewAppId(Params params){
        String id = "";
        long idNum = 0;
        try{
            MySQLConnector connector = params.getDBConnection();
            connector.createStatement();
            String randomVal = randomVal();
            String query = "insert into appid (uniqueName) values ('" + randomVal + "')";
            int upRes =  connector.executeUpdate(query);
            connector.commit();
            query = "select * from appid where uniqueName = '" + randomVal + "'";
            ResultSet rs =  connector.executeQuery(query);
            if (rs != null)
            {
                while(rs.next())
                {
                    idNum = rs.getLong("id");
                }
                rs.close();
            }
            query = "delete from appid where uniqueName = '" + randomVal + "'";
            upRes = connector.executeUpdate(query);
            connector.commit();
            connector.closeStatement();
            connector.closeTheConnection();
            id = "APP" + randomVal().substring(0,32) + String.format("%1$020d",idNum);
        } catch (Exception e) {
            params.log.log(DBHandler.class, "Error: " + e.getMessage());
        }
        return id;
    }


    public static String getInsuranceEndDate(String plateNumber, Params params){
        String endDate = "";
        if (!SanityCheck.noEsc(plateNumber)){
            return  endDate;
        }
        MySQLConnector connector = params.getDBConnection();
        ResultSet rs = connector.executeQuery("SELECT * FROM \n" +
                "plea.insurance ins, " +
                "plea.vehicles veh " +
                "WHERE ins.vehicle = veh.id " +
                "AND veh.registration_plate = '" + plateNumber + "' " +
                "AND ins.enddate > DATE_FORMAT(sysdate(), \"%Y%m%d%h%i%s000\");");
        if (rs != null){
            try {
                if (rs.next())
                {
                    Long ed = rs. getLong("enddate");
                    endDate = TimeConversion.timestampToTime(ed.toString());
                }
                rs.close();
            } catch (Exception e){
                params.log.log(DBHandler.class, "Error: " + e.getMessage());
            }
        }
        connector.closeStatement();
        connector.closeTheConnection();
        return endDate;
    }

    public static ArrayList<Appointment> createAppointment(String applicationId, String officeId, String dtm, Params params){
        ArrayList<Appointment> appointments = new ArrayList<Appointment>();
        if (!SanityCheck.noEsc(applicationId) && !SanityCheck.noEsc(officeId) && !SanityCheck.noEsc(dtm) && !applicationId.isEmpty()){
            return  appointments;
        }

        MySQLConnector connector = params.getDBConnection();
        connector.createStatement();

        if (!applicationId.isEmpty() && !officeId.isEmpty() && !dtm.isEmpty()) {
            String queryIns = "INSERT INTO plea.appointments\n" +
                    "(user, office, datetime, AppID, createdtm)\n" +
                    "VALUES\n" +
                    "(1, " + officeId + ", '" + dtm + "', '" + applicationId + "', NULL)";
            int upRes = connector.executeUpdate(queryIns);
            connector.commit();
        }

        String query = "SELECT \n" +
                "app.id as App, app.datetime as DTM, off.address as Address, ci.city as City, off.id as OfficeID\n" +
                "FROM\n" +
                " plea.appointments AS app\n" +
                "LEFT JOIN\n" +
                "plea.offices AS off ON app.office = off.id\n" +
                "LEFT JOIN\n" +
                "plea.cities as ci ON ci.id = off.city\n" +
                "WHERE\n" +
                "app.AppID = '" + applicationId + "'";
        ResultSet rs = connector.executeQuery(query);
        try {
            if (rs != null) {
                while (rs.next()) {
                    Appointment app = new Appointment();
                    app.setApp(rs.getString("App"));
                    app.setdTM(rs.getString("DTM"));
                    app.setOfficeAddress(rs.getString("Address"));
                    app.setOfficeId(rs.getString("OfficeID"));
                    app.setCity(rs.getString("City"));
                    appointments.add(app);
                }
                rs.close();
            }
        } catch (Exception e){
            params.log.log(DBHandler.class, "Error: " + e.getMessage());
        }
        connector.closeStatement();
        connector.closeTheConnection();
        return appointments;
    }


    public static VehPriceInfo getVehicleInfo(String vehicle, String vehCapacity, String city, Params params){
        VehPriceInfo vehInfo = new VehPriceInfo();
        if (!SanityCheck.noEsc(vehicle) && !SanityCheck.noEsc(vehCapacity) && !SanityCheck.noEsc(city)){
            return  vehInfo;
        }
        MySQLConnector connector = params.getDBConnection();
        connector.createStatement();
        String query = "SELECT pri.price, pri.dateend, pri.vehcategory, pri.vehcapacity, pri.citycategory, vehcat.veh FROM " +
                "plea.prices pri, " +
                "plea.vehicles_categories vehcat, " +
                "plea.cities cit " +
                "WHERE pri.vehcategory = vehcat.id " +
                "AND pri.citycategory = cit.category " +
                "AND ( pri.dateend > DATE_FORMAT(sysdate(), '%Y%m%d%h%i%s000') OR pri.dateend IS NULL) " +
                "AND cit.city = '" + city + "' AND vehcat.veh = '" + vehicle + "' AND pri.vehcapacity = '" + vehCapacity + "' " +
                "LIMIT 1";
        ResultSet rs = connector.executeQuery(query);
        try {
            if (rs != null) {
                if (rs.next()) {
                    vehInfo.setPrice(rs.getString("price"));
                    vehInfo.setDateend(rs.getString("dateend"));
                    vehInfo.setVehcategory(rs.getString("vehcategory"));
                    vehInfo.setVehcapacity(rs.getString("vehcapacity"));
                    vehInfo.setCitycategory(rs.getString("citycategory"));
                    vehInfo.setVehicle(rs.getString("veh"));
                }
                rs.close();
            }
        } catch (Exception e){
            params.log.log(DBHandler.class, "Error: " + e.getMessage());
        }
        connector.closeStatement();
        connector.closeTheConnection();
        return vehInfo;
    }
}
