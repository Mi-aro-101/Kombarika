package ambovombe.kombarika.generator.service;

import java.util.HashMap;
import java.util.List;

import ambovombe.kombarika.configuration.mapping.LanguageProperties;
import ambovombe.kombarika.generator.utils.ObjectUtility;

public class GeneratorService {
 
    public static String getPackage(LanguageProperties languageProperties, String packageName){
        return languageProperties.getPackageSyntax() + " " + packageName + ";\n";
    }

    public static String getFileName(String table, String extension){
        return ObjectUtility.capitalize(ObjectUtility.formatToCamelCase(table)).concat("." + extension);
    }
    
    public static String getPrimaryKeyName(HashMap<String, String> fk, List<String> pk)throws Exception{
    	String primaryKey = "";
    	
    	for(String id : pk) {
    		if(!fk.containsKey(id))
    			primaryKey = id; break;
    	}
    	
    	return primaryKey;
    }
}
