/**
 * 
 */
package ambovombe.kombarika.generator.service.view;

import java.io.File;
import java.util.HashMap;
import java.util.List;

import ambovombe.kombarika.database.DbConnection;
import ambovombe.kombarika.generator.parser.FileUtility;
import ambovombe.kombarika.generator.service.DbService;
import ambovombe.kombarika.generator.service.GeneratorService;
import ambovombe.kombarika.generator.utils.ObjectUtility;
import ambovombe.kombarika.utils.Misc;

/**
 * 
 */
public class CrudViewGenerator {
	
	public String getInputInsert()throws Exception{
		String result = "";
		
		return result;
	}
	
	public String generateCreatePage(View view, String table, String url, DbConnection dbConnection)throws Exception{
		String result = "";
		String tempPath = Misc.getViewTemplateLocation().concat(File.separator).concat(view.getViewProperties().getTemplates().get("CreateEdit"));
		String template = FileUtility.readOneFile(tempPath);
		// Get the primary keys name column of the table
		List<String> primaryKeys = DbService.getPrimaryKey(dbConnection, table);
        String path =  ObjectUtility.formatToCamelCase(table);
        path = view.getFrameworkProperties().getControllerProperty().getPathSyntax().replace("?", path);
        HashMap<String, String> columns = DbService.getDetailsColumn(dbConnection.getConnection(), table);
        HashMap<String, String> foreignKeys = DbService.getForeignKeys(dbConnection, table);
        HashMap<String, String> idAndAttribute = view.getIdAndAttribute(dbConnection, foreignKeys);
        String id = idAndAttribute.get("id");
        String attribute = idAndAttribute.get("attribute");
        // Get the true unique primary key of this table
        String properPk = GeneratorService.getPrimaryKeyName(foreignKeys, primaryKeys);
        
        result = template.replace("#entity#", ObjectUtility.formatToSpacedString(table)).
        		replace("#inputInsert#", getInputInsert());
        
		return result;
	}
	
}
