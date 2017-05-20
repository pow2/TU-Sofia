package bg.tusofia.generalfunctionality;

import java.io.*;

public class LogManager {
    private File file;
    private FileWriter filewritter;
    private BufferedWriter bufferwritter;

    private void createNewLogFile(){
        String filename = file.getName();
        File file1 = new File("old_" + filename);
        if(file1.exists()){
            file1.delete();
        }
        close();
        file.renameTo(file1);
        file = new File(filename);
        try {
            file.createNewFile();
        } catch (IOException e) {
            e.printStackTrace();
        }
        reloadWriteResources();
    }

    public synchronized void log(String classname, String data) {
        try {
            String logdata = TimeConversion.unixTimeToDateTime(System.currentTimeMillis()) +
                             "\r\n" + classname +
                             "\r\n" + data + "\r\n\r\n";
            if(file.length() > 10 * 1024 * 1024){
                createNewLogFile();
            }
            bufferwritter.write(logdata);
            bufferwritter.flush();

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public synchronized void log(Object o, String data) {
        log(o.getClass().getName(), data);
    }

    public synchronized void log(String data) {
        log("Class unknown", data);
    }

    public LogManager(String filename) {
        if (filename.length() > 4){
            if(!filename.substring(filename.length()-4, filename.length()).equals(".log")){
                filename += ".log";
            }
        }
        else if (filename.isEmpty()){
            filename = "Serv.log";
        }
        else {
            filename += ".log";
        }
        file = new File(filename);
        if(!file.exists()) {
            try {
                file.createNewFile();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        reloadWriteResources();
    }

    private void reloadWriteResources(){
        try {
            filewritter = new FileWriter(file.getName(),true);
            bufferwritter = new BufferedWriter(filewritter);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void close(){
        try {
            filewritter.close();
            bufferwritter.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

}
