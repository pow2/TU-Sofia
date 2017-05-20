package bg.tusofia.generalfunctionality;

public class SanityCheck {
    public static boolean noEsc(String s){
        boolean result = true;
        if (s.contains("'")){
            result = false;
        }
        return result;
    }
}
