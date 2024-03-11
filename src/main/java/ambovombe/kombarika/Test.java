package ambovombe.kombarika;
/*entity
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */

import ambovombe.kombarika.generator.CodeGenerator;
import ambovombe.kombarika.generator.service.DbService;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.sql.SQLException;

/**
 *
 * @author Mamisoa
 */
public class Test {

    static String readProjectName() throws IOException {
        // Enter data using BufferReader
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));

        System.out.println("Package name:");
        System.out.print("=> ");
        // Reading data using readLine
        return reader.readLine().toString();
    }

    /**
     * @param args the command line arguments
     * @throws SQLException
     */

    public static void main(String[] args) throws Exception {
        CodeGenerator codeGenerator = new CodeGenerator();
        String path = "Generated";
        // String viewPath = "/home/mamisoa/ITU/L3/Mr_Naina/REACT/crud/src/components";
        String framework = "csharp:dotnet";
        String packageName = readProjectName();
        String entity = "entity";
        String controller = "controller";
        String repository = "repository";
        // String view = "";
        // String viewType = "react";
        // String url = "http://localhost:8080/";
        try {
            // String[] tables = {"district","region"};
            // DbConnection dbConnection = codeGenerator.getDbConnection();
            // String str =
            // dbConnection.getListConnection().get(dbConnection.getInUseConnection()).getDatabaseType().getForeignKeyQuery();
            // str = str.replace("?", "commune");
            // System.out.println(str);
            // HashMap<String, String> foreignKeys = DbService.getForeignKeys(dbConnection,
            // "commune");
            // for (Map.Entry<String, String> set : foreignKeys.entrySet()) {
            // System.out.println(set.getKey() + " " + set.getValue());
            // }
            String[] tables = DbService.getAllTablesArrays(codeGenerator.getDbConnection());
            // for(String table: tables)
            // System.out.println(table);

            /* My test */
            codeGenerator.generateAllEntity(path, tables, packageName, entity, framework);
            codeGenerator.generateAllRepository(path, tables, packageName, entity, repository, framework);
            codeGenerator.generateAllController(path, tables, packageName, entity, controller, repository, framework);

            /* Main test */
            // codeGenerator.generateAll(path, viewPath, packageName, entity, controller,
            // repository, view, viewType, url, tables, framework);
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            codeGenerator.getDbConnection().close();
        }
    }
}
