package bg.tusofia.generalfunctionality;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.TimeZone;
import java.util.Date;

public class TimeConversion {

    public static long dateTimeToUnixTime(String time) {
        DateFormat dfm = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.SSS");
        long unixtime = 0;
        //dfm.setTimeZone(TimeZone.getTimeZone("UTC+2:00"));//Specify your timezone
        try
        {
            unixtime = dfm.parse(time).getTime();
            unixtime = unixtime/1000;
        }
        catch (ParseException e)
        {
            System.out.println(e.getMessage());
            unixtime = 0;
        }
        return unixtime;
    }

    public static String timestampToTime(String ts) {
        DateFormat dfm = new SimpleDateFormat("yyyyMMddHHmmssSSS");
        String time = "";
        //dfm.setTimeZone(TimeZone.getTimeZone("UTC+2:00"));//Specify your timezone
        try
        {
            Date uTime = dfm.parse(ts);
            DateFormat date = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.SSS");
            time = date.format(uTime);
        }
        catch (ParseException e)
        {
            System.out.println(e.getMessage());

        }
        return time;
    }

    public static String tsToShortTime(String ts) {
        DateFormat dfm = new SimpleDateFormat("yyyyMMddHHmmssSSS");
        String time = "";
        //dfm.setTimeZone(TimeZone.getTimeZone("UTC+2:00"));//Specify your timezone
        try
        {
            Date uTime = dfm.parse(ts);
            DateFormat date = new SimpleDateFormat("yyyy-MM-dd HH:mm");
            time = date.format(uTime);
        }
        catch (ParseException e)
        {
            System.out.println(e.getMessage());
        }
        return time;
    }

    public static String unixTimeToDateTime(long unixTime) {
        DateFormat date = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.SSS");
        Date uTime = new Date(unixTime);
        String strDate = date.format(uTime);
        return strDate;
    }

    public static String getCurrentTimestamp() {
        DateFormat date = new SimpleDateFormat("yyyyMMddHHmmssSSS");
        Date uTime = new Date();
        String strDate = date.format(uTime);
        return strDate;
    }

}

