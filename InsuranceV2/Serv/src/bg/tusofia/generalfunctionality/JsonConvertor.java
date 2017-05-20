package bg.tusofia.generalfunctionality;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.internal.Primitives;

import java.lang.reflect.Type;

public class JsonConvertor {

    public static <T> T fromJson(String inputJson, Class<T> classOfT){
        Gson gson = new GsonBuilder().create();
        Object object = gson.fromJson(inputJson, (Type)classOfT);
        return Primitives.wrap(classOfT).cast(object);
    }

    public static String toJson(Object src){
        return (new GsonBuilder().create()).toJson(src);
    }
}

