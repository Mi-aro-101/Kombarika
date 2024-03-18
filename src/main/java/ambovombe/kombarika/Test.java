package ambovombe.kombarika;
/*entity
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */

import ambovombe.kombarika.generator.CodeGenerator;
import ambovombe.kombarika.generator.service.DbService;
import ambovombe.kombarika.utils.ProjectSetup;

import java.util.HashMap;
/**
 *
 *  @author Mamisoa
 */
import java.util.Map;
import java.util.Scanner;

import com.google.gson.Gson;
public class Test {
	
	private static ProjectSetup inputInterface()throws Exception{
		ProjectSetup setupBuilder = new ProjectSetup();
		Map<String, String> result = new HashMap<String, String>();
		Scanner scanner = new Scanner(System.in);
		System.out.println("Choose your framework :-)\n");
		Map<Integer, String> frameworks = setupBuilder.loadAllFramework();
		for(Map.Entry<Integer, String> framework : frameworks.entrySet()) {
			System.out.println(framework.getKey()+" : "+framework.getValue());
		}
		String framework = frameworks.get(Integer.parseInt(scanner.nextLine()));
		setupBuilder = ProjectSetup.getFrameworkSetupConfig(framework);
		
		Scanner newold = new Scanner(System.in);
		System.out.println("1:Create");
		System.out.println("2:Use existing");
		String response = newold.nextLine();
		
		switch (response) {
			case "1":
				setupBuilder.generateProject();
				break;
			case "2":
				setupBuilder.useExistingProject();
				break;
			default:
				break;
		}
		
		return setupBuilder;
	}

    /**
     * @param args the command line arguments
     * @throws SQLException
     */
     
    public static void main(String[] args) throws Exception {
    	ProjectSetup builder = null;
    	try {
			builder = inputInterface();
		} catch (Exception e) {
			e.printStackTrace();
		}
    	
        CodeGenerator codeGenerator = new CodeGenerator();  
        // Location of the generated code (Entity, Controller, Repository, ...)
        String path = builder.getRoot();
        // Location of the views
        String viewPath = builder.getRoot();
        // Choose framework
        String framework = builder.getName();
        // Package name where to put the files generated (root directory of all)
        String packageName = builder.getPackageName();
        // Package name for entity generated file
        String entity = builder.getEntity();
        // Package name for controller generated file
        String controller = builder.getController();
        // Package name for repository/context generated file
        String repository = builder.getRepository();
        // Views root directory
        String view = builder.getView();
        // View type language
        String viewType = builder.getViewType();
        
        String url = "http://localhost:8080/";
        try{
            // String[] tables = {"district","region"};
            // DbConnection dbConnection = codeGenerator.getDbConnection();
            // String str = dbConnection.getListConnection().get(dbConnection.getInUseConnection()).getDatabaseType().getForeignKeyQuery();
            // str = str.replace("?", "commune");
            // System.out.println(str);
            // HashMap<String, String> foreignKeys = DbService.getForeignKeys(dbConnection, "commune");
            // for (Map.Entry<String, String> set : foreignKeys.entrySet()) {
            //     System.out.println(set.getKey() + " " + set.getValue());
            // }
            String[] tables = DbService.getAllTablesArrays(codeGenerator.getDbConnection());
            // for(String table: tables)
            //     System.out.println(table);
            
            /* My test */
//            codeGenerator.generateAllEntity(path, tables, packageName, entity, framework);
//            codeGenerator.generateAllRepository(path, tables, packageName, entity, repository, framework);
//            codeGenerator.generateAllController(path, tables, packageName, entity, controller, repository, framework);
            /* Main test */
            codeGenerator.generateAll(path, viewPath, packageName, entity, controller, repository, view, viewType, url, tables, framework);
        }catch(Exception e){
            e.printStackTrace();
        }finally{
            codeGenerator.getDbConnection().close();
        }
    }
}
