package bg.tusofia;

public class DEBUG {
    private static boolean enabled = true;
    public static void write(String str, Class c){
        if (enabled){
            System.out.println(c.getName() + ":" + str);
        }
    }
}
