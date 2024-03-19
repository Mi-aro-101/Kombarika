/**
 * 
 */
package ambovombe.kombarika.generator.service.view;

import java.io.File;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

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
	
	public String getInputInsert(View view, HashMap<String, String> columns, HashMap<String, String> foreignKeys, String pk)throws Exception{
		String result = "";
		String template = view.getViewProperties().getInputInsert();
		String templateFk = view.getViewProperties().getSelect();
		String tpl = "";
		for(Map.Entry<String, String> set : columns.entrySet()) {
			if(set.getKey().equals(pk)) continue;
			String fk = foreignKeys.get(set.getKey());
			if(fk != null) {
				tpl = templateFk;
				String colName = ObjectUtility.formatToCamelCase(set.getKey());
				tpl = tpl.replace("#name#", colName);
			}
			else if(fk == null || fk.equals("")) {
				tpl = template;
				String colName = ObjectUtility.formatToCamelCase(set.getKey());
				tpl = tpl.replace("#name#", colName);
			}
			result += tpl; 
		}
		return result;
	}
	
	public String getInputUpdate(View view, String properPk) {
		String result = "";
		String template = view.getViewProperties().getInputUpdate();
		properPk = ObjectUtility.formatToCamelCase(properPk);
		result = template.replace("#id#", properPk);
		return result;
	}
	
	public String getTableHeader(View view, HashMap<String, String> columns, HashMap<String, String> foreignKeys, String pk)throws Exception{
		String result = "";
		String template = view.getViewProperties().getTableHeader();
		String tpl = "";
		for(Map.Entry<String, String> set : columns.entrySet()) {
			if(!set.getKey().equals(pk)) {
				tpl = template;
				String colName = ObjectUtility.formatToCamelCase(set.getKey());
				tpl = tpl.replace("#name#", colName);
			}
			result+=tpl;
		}
		return result;
	}
	
	public String getTableValue(View view, HashMap<String, String> columns, HashMap<String, String> foreignKeys, String pk)throws Exception{
		String result = "";
		String template = view.getViewProperties().getTableValue();
		String tpl = "";
		for(Map.Entry<String, String> set : columns.entrySet()) {
			if(!set.getKey().equals(pk)) {
				tpl = template;
				String colName = ObjectUtility.formatToCamelCase(set.getKey());
				tpl = tpl.replace("#name#", colName);
			}
			result+=tpl;
		}
		return result;
	}
	
	public String generateCreatePage(View view, String table, String url, DbConnection dbConnection, String modelPackage)throws Exception{
		String result = "";
		String tempPath = Misc.getViewTemplateLocation().concat(File.separator).concat(view.getViewProperties().getTemplates().get("Create"));
		String template = FileUtility.readOneFile(tempPath);
		// Get the primary keys name column of the table
		List<String> primaryKeys = DbService.getPrimaryKey(dbConnection, table);
        String path =  ObjectUtility.formatToCamelCase(table);
        path = view.getFrameworkProperties().getControllerProperty().getPathSyntax().replace("?", path);
        // Columns => key:column ; value:type
        HashMap<String, String> columns = DbService.getDetailsColumn(dbConnection.getConnection(), table);
        // Foreign key Map => key:column ; value:table
        HashMap<String, String> foreignKeys = DbService.getForeignKeys(dbConnection, table);
        HashMap<String, String> idAndAttribute = view.getIdAndAttribute(dbConnection, foreignKeys);
        String id = idAndAttribute.get("id");
        String attribute = idAndAttribute.get("attribute");
        // Get the true unique primary key of this table
        String properPk = GeneratorService.getPrimaryKeyName(foreignKeys, primaryKeys);
        String tableClassName = GeneratorService.toFirstUpperCase(ObjectUtility.formatToCamelCase(table));
        result = template.replace("#entity#", ObjectUtility.formatToSpacedString(table)).
        		replace("#inputInsert#", getInputInsert(view, columns, foreignKeys, properPk)).
        		replace("#package#", modelPackage+"."+tableClassName); 
        
		return result.replace("#action#", "Create");
	}
	
	public String generateEditPage(View view, String table, String url, DbConnection dbConnection, String modelPackage)throws Exception{
		String result = "";
		String tempPath = Misc.getViewTemplateLocation().concat(File.separator).concat(view.getViewProperties().getTemplates().get("Edit"));
		String template = FileUtility.readOneFile(tempPath);
		// Get the primary keys name column of the table
		List<String> primaryKeys = DbService.getPrimaryKey(dbConnection, table);
        String path =  ObjectUtility.formatToCamelCase(table);
        path = view.getFrameworkProperties().getControllerProperty().getPathSyntax().replace("?", path);
        // Columns => key:column ; value:type
        HashMap<String, String> columns = DbService.getDetailsColumn(dbConnection.getConnection(), table);
        // Foreign key Map => key:column ; value:table
        HashMap<String, String> foreignKeys = DbService.getForeignKeys(dbConnection, table);
        HashMap<String, String> idAndAttribute = view.getIdAndAttribute(dbConnection, foreignKeys);
        String id = idAndAttribute.get("id");
        String attribute = idAndAttribute.get("attribute");
        // Get the true unique primary key of this table
        String properPk = GeneratorService.getPrimaryKeyName(foreignKeys, primaryKeys);
        String tableClassName = GeneratorService.toFirstUpperCase(ObjectUtility.formatToCamelCase(table));
        result = template.replace("#entity#", ObjectUtility.formatToSpacedString(table)).
        		replace("#inputInsert#", getInputInsert(view, columns, foreignKeys, properPk)).
        		replace("#package#", modelPackage+"."+tableClassName).
        		replace("#idhidden#", getInputUpdate(view, properPk));
        
		return result.replace("#action#", "Edit");
	}
	
	public String generateIndexPage(View view, String table, String url, DbConnection dbConnection, String modelPackage)throws Exception{
		String result = "";
		String tempPath = Misc.getViewTemplateLocation().concat(File.separator).concat(view.getViewProperties().getTemplates().get("Index"));
		String template = FileUtility.readOneFile(tempPath);
		// Get the primary keys name column of the table
		List<String> primaryKeys = DbService.getPrimaryKey(dbConnection, table);
        String path =  ObjectUtility.formatToCamelCase(table);
        path = view.getFrameworkProperties().getControllerProperty().getPathSyntax().replace("?", path);
        // Columns => key:column ; value:type
        HashMap<String, String> columns = DbService.getDetailsColumn(dbConnection.getConnection(), table);
        // Foreign key Map => key:column ; value:table
        HashMap<String, String> foreignKeys = DbService.getForeignKeys(dbConnection, table);
        HashMap<String, String> idAndAttribute = view.getIdAndAttribute(dbConnection, foreignKeys);
        String id = idAndAttribute.get("id");
        String attribute = idAndAttribute.get("attribute");
        // Get the true unique primary key of this table
        String properPk = GeneratorService.getPrimaryKeyName(foreignKeys, primaryKeys);
        String tableClassName = GeneratorService.toFirstUpperCase(ObjectUtility.formatToCamelCase(table));
        result = template.replace("#entity#", ObjectUtility.formatToSpacedString(table)).
        		replace("#tableHeader#", getTableHeader(view, columns, foreignKeys, properPk)).
        		replace("#package#", modelPackage+"."+tableClassName).
        		replace("#tableValue#", getTableValue(view, columns, foreignKeys, properPk)).
        		replace("#id#", ObjectUtility.formatToCamelCase(properPk));
        
		return result;
	}
	
	public String generateDeletePage(View view, String table, String url, DbConnection dbConnection, String modelPackage)throws Exception{
		String result = "";
		String tempPath = Misc.getViewTemplateLocation().concat(File.separator).concat(view.getViewProperties().getTemplates().get("Delete"));
		String template = FileUtility.readOneFile(tempPath);
		// Get the primary keys name column of the table
		List<String> primaryKeys = DbService.getPrimaryKey(dbConnection, table);
        String path =  ObjectUtility.formatToCamelCase(table);
        path = view.getFrameworkProperties().getControllerProperty().getPathSyntax().replace("?", path);
        // Columns => key:column ; value:type
        HashMap<String, String> columns = DbService.getDetailsColumn(dbConnection.getConnection(), table);
        // Foreign key Map => key:column ; value:table
        HashMap<String, String> foreignKeys = DbService.getForeignKeys(dbConnection, table);
        HashMap<String, String> idAndAttribute = view.getIdAndAttribute(dbConnection, foreignKeys);
        String id = idAndAttribute.get("id");
        String attribute = idAndAttribute.get("attribute");
        // Get the true unique primary key of this table
        String properPk = GeneratorService.getPrimaryKeyName(foreignKeys, primaryKeys);
        String tableClassName = GeneratorService.toFirstUpperCase(ObjectUtility.formatToCamelCase(table));
        result = template.replace("#entity#", ObjectUtility.formatToSpacedString(table)).
        		replace("#tableHeader#", getTableHeader(view, columns, foreignKeys, properPk)).
        		replace("#package#", modelPackage+"."+tableClassName).
        		replace("#tableValue#", getTableValue(view, columns, foreignKeys, properPk)).
        		replace("#id#", properPk).
        		replace("#action#", "Delete");
        
		return result;
	}
	
}
