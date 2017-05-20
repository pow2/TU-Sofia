package bg.tusofia.HTTPServ;

import bg.tusofia.Params;
import com.sun.net.httpserver.HttpServer;

import java.io.IOException;
import java.net.InetSocketAddress;
import java.util.concurrent.CountDownLatch;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

public class HttpServ {
    public HttpServ(Params params) throws IOException, InterruptedException {
        HttpServer server = HttpServer.create(new InetSocketAddress(Integer.parseInt(params.getHttpsrvPort())), 0);
        final CountDownLatch countDown = new CountDownLatch(1);
        server.createContext("/", new RootHandler());
        server.createContext("/checkifactive", new CheckifactiveHandler(params));
        server.createContext("/calculate", new CalcHandler(params));
        server.createContext("/makeanappointment1", new AppointmentOneHandler(params));
        server.createContext("/makeanappointment2", new AppointmentTwoHandler(params));
        server.createContext("/appointment", new AppointmentThreeHandler(params));
        server.createContext("/getNewAppId", new GetNewAppId(params));
        ExecutorService httpThreadPool = Executors.newFixedThreadPool(16);
        server.setExecutor(httpThreadPool);
        server.start();
        params.log.log(this, "Info: " + "HTTP server started successfully!");
        countDown.await();
        /*
        while (!Thread.currentThread().isInterrupted()) {

            Thread.sleep(100);
        }
        */
        httpThreadPool.shutdown();
        httpThreadPool.awaitTermination(1, TimeUnit.HOURS);
        server.stop(1);
        params.log.log(this, "Info: " + "HTTP server was stopped!");
    }
}
