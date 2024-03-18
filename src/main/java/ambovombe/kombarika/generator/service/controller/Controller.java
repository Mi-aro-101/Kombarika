package ambovombe.kombarika.generator.service.controller;

import ambovombe.kombarika.database.DbConnection;

import java.util.HashMap;
import java.util.List;
import java.util.Map.Entry;

import ambovombe.kombarika.configuration.mapping.*;
import ambovombe.kombarika.generator.service.DbService;
import ambovombe.kombarika.generator.service.GeneratorService;
import ambovombe.kombarika.generator.utils.ObjectUtility;
import ambovombe.kombarika.utils.Misc;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class Controller {
        LanguageProperties languageProperties;
        FrameworkProperties frameworkProperties;
        TypeMapping typeMapping;
        CrudMethod crudMethod;
        ControllerProperty controllerProperty;
        AnnotationProperty annotationProperty;
        Imports imports;
        DbConnection dbConnection;

        /**
         * Generate the function that make the insert to the database
         * 
         * @param table
         * @param language
         * @param method
         * @param controllerProperty
         * @return the string form of the function
         * @throws Exception
         */
        public String save(String table) throws Exception {
                String body = "";
                String args = "";
                // args += this.getLanguageProperties().getAnnotationSyntax().replace("?",
                // this.getControllerProperty().getAnnotationArgumentParameterFormData()) + " "
                // + ObjectUtility.capitalize(ObjectUtility.formatToCamelCase(table)) + " "
                // + ObjectUtility.formatToCamelCase(table);
                String primaryKeyType = "";
                String primaryKeyColumn = getPrimaryKey(table);
                String fields = getFields(table);
                try {
                        primaryKeyType = getPrimaryKeyType(table);
                        primaryKeyType = this.typeMapping.getListMapping().get(primaryKeyType).getType();
                } catch (Exception e) {
                        primaryKeyType = "int";
                }
                args += this.crudMethod.getSave().getParameter()
                                .replace("#typePrimaryKey#", primaryKeyType)
                                .replace("#object#", ObjectUtility.formatToCamelCase(table))
                                .replace("?", ObjectUtility.capitalize(ObjectUtility.formatToCamelCase(table)))
                                .replace("#fields#", "\"" + fields + "\"")
                                .replace("#nullable#", languageProperties.getNullable());
                body += Misc.tabulate(this.getCrudMethod().getSave().getContent()
                                .replace("#primaryKeyField#", primaryKeyColumn)
                                .replace("#object#", ObjectUtility.formatToCamelCase(table))
                                .replace("?", ObjectUtility.capitalize(ObjectUtility.formatToCamelCase(table))));
                String function = this.getLanguageProperties().getMethodSyntax()
                                .replace("#name#", this.crudMethod.getSave().getFunction())
                                .replace("#type#",
                                                this.getControllerProperty().getReturnType().replace("?",
                                                                ObjectUtility.capitalize(ObjectUtility
                                                                                .formatToCamelCase(table))))
                                .replace("#arg#", args)
                                .replace("#body#", body);
                String viewFunction = this.crudMethod.getSave().getView()
                                .replace("#typePrimaryKey#", primaryKeyType)
                                .replace("?", ObjectUtility.capitalize(ObjectUtility.formatToCamelCase(table)))
                                .replace("#foreignKey#", generateForeignObjectToView(table))
                                .replace("#primaryKeyField#", primaryKeyColumn)
                                .replace("#object#", ObjectUtility.formatToCamelCase(table))
                                .replace("#nullable#", languageProperties.getNullable());
                return Misc.tabulate(this.getLanguageProperties().getAnnotationSyntax().replace("?",
                                this.getControllerProperty().getPost()
                                                .replace("?", ObjectUtility.formatToCamelCase(table)))
                                + "\n" + function) + viewFunction;
        }

        public String update(String table) throws Exception {
                String body = "";
                String args = "";
                // args += this.getLanguageProperties().getAnnotationSyntax().replace("?",
                // this.getControllerProperty().getAnnotationArgumentParameterFormData()) + " "
                // + ObjectUtility.capitalize(ObjectUtility.formatToCamelCase(table)) + " "
                // + ObjectUtility.formatToCamelCase(table);
                String fields = getFields(table);
                String primaryKeyType = "";
                String primaryKeyColumn = getPrimaryKey(table);
                try {
                        primaryKeyType = getPrimaryKeyType(table);
                        primaryKeyType = this.typeMapping.getListMapping().get(primaryKeyType).getType();
                } catch (Exception e) {
                        primaryKeyType = "int";
                }
                args += this.crudMethod.getUpdate().getParameter()
                                .replace("#fields#", "\"" + fields + "\"")
                                .replace("#typePrimaryKey#", primaryKeyType)
                                .replace("#object#", ObjectUtility.formatToCamelCase(table))
                                .replace("?", ObjectUtility.capitalize(ObjectUtility.formatToCamelCase(table)))
                                .replace("#nullable#", languageProperties.getNullable());
                body += Misc.tabulate(this.getCrudMethod().getUpdate().getContent()
                                .replace("#primaryKeyField#", primaryKeyColumn)
                                .replace("#object#", ObjectUtility.formatToCamelCase(table))
                                .replace("?", ObjectUtility.capitalize(ObjectUtility.formatToCamelCase(table))));
                String function = this.getLanguageProperties().getMethodSyntax()
                                .replace("#name#", this.crudMethod.getUpdate().getFunction())
                                .replace("#type#", this.getControllerProperty().getReturnType().replace("?",
                                                ObjectUtility.capitalize(ObjectUtility
                                                                .formatToCamelCase(table))))
                                .replace("#arg#", args)
                                .replace("#body#", body);

                String viewFunction = this.crudMethod.getUpdate().getView()
                                .replace("#primaryKeyField#", primaryKeyColumn)
                                .replace("#object#", ObjectUtility.formatToCamelCase(table))
                                .replace("?", ObjectUtility.capitalize(ObjectUtility.formatToCamelCase(table)))
                                .replace("#typePrimaryKey#", primaryKeyType)
                                .replace("#foreignKey#", generateForeignObjectToView(table))
                                .replace("#nullable#", languageProperties.getNullable());

                return Misc.tabulate(this.getLanguageProperties().getAnnotationSyntax().replace("?",
                                this.getControllerProperty().getPut()
                                                .replace("?", ObjectUtility.formatToCamelCase(table)))
                                + "\n" + function) + viewFunction;
        }

        public String delete(String table) throws Exception {
                String body = "";
                String args = "";
                // args += this.getLanguageProperties().getAnnotationSyntax().replace("?",
                // this.getControllerProperty().getAnnotationArgumentParameterFormData()) + " "
                // + ObjectUtility.capitalize(ObjectUtility.formatToCamelCase(table)) + " "
                // + ObjectUtility.formatToCamelCase(table);
                String primaryKeyType = "";
                String fields = getFields(table);
                String primaryKeyColumn = getPrimaryKey(table);
                try {
                        primaryKeyType = getPrimaryKeyType(table);
                        primaryKeyType = this.typeMapping.getListMapping().get(primaryKeyType).getType();
                } catch (Exception e) {
                        primaryKeyType = "int";
                }
                args += this.crudMethod.getDelete().getParameter()
                                .replace("#fields#", "\"" + fields + "\"")
                                .replace("#typePrimaryKey#", primaryKeyType)
                                .replace("#object#", ObjectUtility.formatToCamelCase(table))
                                .replace("?", ObjectUtility.capitalize(ObjectUtility.formatToCamelCase(table)))
                                .replace("#nullable#", languageProperties.getNullable());
                body += Misc.tabulate(this.getCrudMethod().getDelete().getContent()
                                .replace("#primaryKeyField#", primaryKeyColumn)
                                .replace("#object#", ObjectUtility.formatToCamelCase(table))
                                .replace("?", ObjectUtility.capitalize(ObjectUtility.formatToCamelCase(table))));
                String function = this.getLanguageProperties().getMethodSyntax()
                                .replace("#name#", this.crudMethod.getDelete().getFunction())
                                .replace("#type#",
                                                this.getControllerProperty().getReturnTypeDelete().replace("?",
                                                                ObjectUtility.capitalize(ObjectUtility
                                                                                .formatToCamelCase(table))))
                                .replace("#arg#", args)
                                .replace("#body#", body);
                return Misc.tabulate(this.getLanguageProperties().getAnnotationSyntax().replace("?",
                                this.getControllerProperty().getDelete()
                                                .replace("?", ObjectUtility.formatToCamelCase(table)))
                                + "\n" + function);
        }

        public String findAll(String table) {
                String body = "";
                body += Misc.tabulate(this.getCrudMethod().getFindAll().getContent()
                                .replace("#object#", ObjectUtility.formatToCamelCase(table))
                                .replace("?", ObjectUtility.capitalize(ObjectUtility.formatToCamelCase(table))));
                String function = this.getLanguageProperties().getMethodSyntax()
                                .replace("#name#", this.crudMethod.getFindAll().getFunction())
                                .replace("#type#",
                                                this.getControllerProperty().getReturnType().replace("?",
                                                                this.getFrameworkProperties().getListSyntax().replace(
                                                                                "?",
                                                                                ObjectUtility.capitalize(ObjectUtility
                                                                                                .formatToCamelCase(
                                                                                                                table)))))
                                .replace("#arg#", "")
                                .replace("#body#", body);
                return Misc.tabulate(this.getLanguageProperties().getAnnotationSyntax().replace("?",
                                this.getControllerProperty().getGet()
                                                .replace("?", ObjectUtility.formatToCamelCase(table)))
                                + "\n" + function);
        }

        public String findById(String table) throws Exception {
                String body = "";
                String primaryKeyType = "";
                String fields = getFields(table);
                String primaryKeyColumn = getPrimaryKey(table);
                String args = "";
                try {
                        primaryKeyType = getPrimaryKeyType(table);
                        primaryKeyType = this.typeMapping.getListMapping().get(primaryKeyType).getType();
                } catch (Exception e) {
                        primaryKeyType = "int";
                }
                args += this.crudMethod.getFindById().getParameter()
                                .replace("#fields#", "\"" + fields + "\"")
                                .replace("#typePrimaryKey#", primaryKeyType)
                                .replace("#object#", ObjectUtility.formatToCamelCase(table))
                                .replace("?", ObjectUtility.capitalize(ObjectUtility.formatToCamelCase(table)))
                                .replace("#nullable#", languageProperties.getNullable());
                body += Misc.tabulate(this.getCrudMethod().getFindById().getContent()
                                .replace("#object#", ObjectUtility.formatToCamelCase(table))
                                .replace("#primaryKeyField#", primaryKeyColumn)
                                .replace("?", ObjectUtility.capitalize(ObjectUtility.formatToCamelCase(table))));
                String function = this.getLanguageProperties().getMethodSyntax()
                                .replace("#name#", this.crudMethod.getFindById().getFunction())
                                .replace("#type#",
                                                this.getControllerProperty().getReturnType().replace("?",
                                                                this.getFrameworkProperties().getListSyntax().replace(
                                                                                "?",
                                                                                ObjectUtility.capitalize(ObjectUtility
                                                                                                .formatToCamelCase(
                                                                                                                table)))))
                                .replace("#arg#", args)
                                .replace("#body#", body);
                return Misc.tabulate(this.getLanguageProperties().getAnnotationSyntax().replace("?",
                                this.getControllerProperty().getGet()
                                                .replace("?", ObjectUtility.formatToCamelCase(table)))
                                + "\n" + function);
        }

        public String getCrudMethods(String table) throws Exception {
                StringBuilder stringBuilder = new StringBuilder();
                String save = save(table);
                String findById = findById(table);
                String findAll = findAll(table);
                String update = update(table);
                String delete = delete(table);
                stringBuilder.append(save);
                stringBuilder.append("\n");
                stringBuilder.append(update);
                stringBuilder.append("\n");
                stringBuilder.append(delete);
                stringBuilder.append("\n");
                stringBuilder.append(findAll);
                stringBuilder.append("\n");
                stringBuilder.append(findById);
                return stringBuilder.toString();
        }

        public String getControllerField(String table) {
                String res = "";
                if (!this.getControllerProperty().getField().equals("")
                                && !this.getControllerProperty().getAnnotationField().equals("")) {
                        res += "\t"
                                        + this.getLanguageProperties().getAnnotationSyntax().replace("?",
                                                        this.getControllerProperty().getAnnotationField())
                                        + "\n"
                                        + "\t" + this.getControllerProperty().getField().replace("?",
                                                        ObjectUtility.capitalize(
                                                                        ObjectUtility.formatToCamelCase(table)))
                                        + "\n";
                } else if (!this.getControllerProperty().getField().equals("")) {
                        res += "\t" + this.getControllerProperty().getField().replace("?",
                                        ObjectUtility.capitalize(ObjectUtility.formatToCamelCase(table))) + "\n";
                }
                return res;
        }

        public String getControllerClass(String table, String framework) {
                String res = "";
                // Annotation controller
                if (!this.getAnnotationProperty().getController().equals("")) {
                        res += this.getLanguageProperties().getAnnotationSyntax()
                                        .replace("?", this.getAnnotationProperty().getController()) + "\n";
                }
                // Route Annotation controller
                if (!this.getControllerProperty().getPath().equals("")) {
                        res += this.getLanguageProperties().getAnnotationSyntax()
                                        .replace("?", this.getControllerProperty().getPath().replace("?",
                                                        ObjectUtility.formatToCamelCase(table)));
                }
                res = res.replace("?", ObjectUtility.formatToCamelCase(table)) + "\n"
                                + this.getLanguageProperties().getClassSyntax() + " "
                                + ObjectUtility.capitalize(ObjectUtility.formatToCamelCase(
                                                this.getLanguageProperties().getFrameworks().get(framework)
                                                                .getControllerProperty()
                                                                .getClassSyntax())
                                                .replace("?", ObjectUtility.formatToCamelCase(table)));
                return res;
        }

        public String getControllerImport(String repository, String entity, String table) throws Exception {
                String res = "";
                String imp = this.getLanguageProperties().getImportSyntax();
                for (String item : this.getImports().getController()) {
                        item = item
                                        .replace("packageName", repository)
                                        .replace("className",
                                                        ObjectUtility.capitalize(
                                                                        ObjectUtility.formatToCamelCase(table)))
                                        .replace("?", ObjectUtility.capitalize(ObjectUtility.formatToCamelCase(table)))
                                        .replace("entity", entity);
                        res += imp + " " + item + "" + this.getLanguageProperties().getEndOfInstruction() + "\n";
                }
                return res;
        }

        public String getConstructor(String table) throws Exception {
                String res = "";
                if (!this.getControllerProperty().getConstructor().equals("")) {
                        res = this.getControllerProperty().getConstructor()
                                        .replace("#name#", ObjectUtility
                                                        .capitalize(ObjectUtility.formatToCamelCase(table)));
                }
                return res;
        }

        public String generateController(String template, String table, String packageName, String repository,
                        String entity, String framework) throws Exception {
                String res = template
                                .replace("#package#",
                                                GeneratorService.getPackage(this.getLanguageProperties(), packageName))
                                .replace("#imports#", getControllerImport(repository, entity, table))
                                .replace("#class#", getControllerClass(table, framework))
                                .replace("#open-bracket#", languageProperties.getOpenBracket())
                                .replace("#close-bracket#", languageProperties.getCloseBracket())
                                .replace("#fields#", getControllerField(table))
                                .replace("#constructors#", getConstructor(table))
                                .replace("#methods#", getCrudMethods(table))
                                .replace("#encapsulation#", "");
                return res;
        }

        private String getPrimaryKeyType(String table) throws Exception {
                List<String> primaryKeyColumn = DbService.getPrimaryKeyType(dbConnection, table);
                for (String string : primaryKeyColumn) {
                        return string;
                }
                return "";
        }

        private String getPrimaryKey(String table) throws Exception {
                List<String> primaryKeyColumn = DbService.getPrimaryKey(dbConnection, table);
                try {
                        return ObjectUtility.formatToCamelCase(primaryKeyColumn.get(0));
                } catch (IndexOutOfBoundsException e) {
                        return "";
                }
        }

        private String getFields(String table) throws Exception {
                String toReturn = "";
                HashMap<String, String> columns = DbService.getColumnNameAndType(dbConnection.getConnection(), table);
                int i = 0;
                for (Entry<String, String> set : columns.entrySet()) {
                        toReturn += ObjectUtility.formatToCamelCase(set.getKey());
                        if (i != columns.size() - 1) {
                                toReturn += ",";
                        }
                        i++;
                }
                return toReturn;
        }

        private String generateForeignObjectToView(String table) throws Exception {
                HashMap<String, String> foreignKeys = DbService.getForeignKeys(dbConnection, table);
                String toReturn = "";
                String temp = null;
                for (Entry<String, String> foreignKey : foreignKeys.entrySet()) {
                        temp = ObjectUtility.capitalize(
                                        ObjectUtility.formatToCamelCase(foreignKey.getValue()));
                        if (temp != null) {
                                toReturn += "\n\t\t" + controllerProperty.getPassValueToView()
                                                .replace("#foreignKeyField#",
                                                                ObjectUtility.formatToCamelCase(foreignKey.getKey()))
                                                .replace("#foreignObject#", temp);
                        }
                        toReturn += "\n\t\t";
                }
                return toReturn;
        }

}
