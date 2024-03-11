package ambovombe.kombarika;
/*entity
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */

import ambovombe.kombarika.generator.CodeGenerator;
import ambovombe.kombarika.generator.service.DbService;

import java.util.HashMap;
/**
 *
 *  @author Mamisoa
 */
public class Test {

    /**
     * @param args the command line arguments
     * @throws SQLException
     */
     
    public static void main(String[] args) throws Exception {
        CodeGenerator codeGenerator = new CodeGenerator();  
        // Location of the generated code (Entity, Controller, Repository, ...)
        String path = "GENERATED";
        // Location of the views
        String viewPath = "GENERATED";
        // Choose framework
        String framework = "csharp:dotnet";
        // Package name where to put the files generated (root directory of all)
        String packageName = "src";
        // Package name for entity generated file
        String entity = "entity";
        // Package name for controller generated file
        String controller = "controller";
        // Package name for repository/context generated file
        String repository = "repository";
        // Views root directory
        String view = "views";
        // View type language
        String viewType = "razor";
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
