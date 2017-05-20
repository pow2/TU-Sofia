package bg.tusofia.HTTPServ;

import bg.tusofia.DEBUG;
import bg.tusofia.generalfunctionality.Utf8LenCounter;
import com.sun.net.httpserver.HttpExchange;
import com.sun.net.httpserver.HttpHandler;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;

public class RootHandler implements HttpHandler {
    @Override
    public void handle(HttpExchange he) throws IOException {
        String response = "<html><head>" +
                "<style>body {\nbackground-color: black;\n}" +
                "div {\nheight: 100px;\nwidth: 600px;\nfont-size: 50px;\ncolor: white;\nposition: fixed;\n" +
                "top: 50%;\nleft: 50%;\nmargin-top: -50px;\nmargin-left: -300px;\n}\n</style>" +
                "</head><body><div>THE API IS RUNNING.</div></body></html>";
        sendResponseMessage(he, response);
    }

    public static String getRequestMessage(HttpExchange he) throws IOException {
        InputStreamReader isr =  new InputStreamReader(he.getRequestBody(),"utf-8");
        BufferedReader br = new BufferedReader(isr);
        int b;
        StringBuilder buf = new StringBuilder(4096);
        while ((b = br.read()) != -1) {
            buf.append((char) b);
        }
        br.close();
        isr.close();
        return buf.toString();
    }

    public static void sendResponseMessage(HttpExchange he, String response) throws IOException {
        he.sendResponseHeaders(200, Utf8LenCounter.length(response));
        OutputStream os = he.getResponseBody();
        os.write(response.getBytes("utf-8"));
        os.flush();
        os.close();
    }
}