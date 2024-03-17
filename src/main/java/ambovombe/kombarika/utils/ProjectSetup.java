/**
 * 
 */
package ambovombe.kombarika.utils;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.InputStream;
import java.io.OutputStream;
import java.lang.reflect.Type;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.concurrent.TimeUnit;

import javax.swing.JFileChooser;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import com.google.gson.stream.JsonReader;

import ambovombe.kombarika.generator.parser.JsonUtility;
import ambovombe.kombarika.generator.utils.CommandRunner;

/**
 * JsonPath : conf/generator/projectSetup.json
 */
public class ProjectSetup {
	
	String root;
	String path;
	String viewPath;
	String framework;
    String packageName;
    String entity;
    String controller;
    String repository;
    String view;
    String viewType;
    String url;
    String cliGeneration;
    String name;
    
    /**
     * Load json file to get all the parameters set to create a project of the designed framework
     * @return
     * @throws Exception any
     */
    public static Map<String, ProjectSetup> loadProjectSetup()throws Exception{
    	Map<String, ProjectSetup> result = new HashMap<String, ProjectSetup>();
    	String confpathFile = Misc.getGeneratorConfLocation()+File.separator+"projectSetup.json";
    	Type type = new TypeToken<HashMap<String, ProjectSetup>>(){}.getType();
    	JsonReader reader = new JsonReader(new BufferedReader(new FileReader(confpathFile)));
    	result = new Gson().fromJson(reader, type);
    	
    	return result;
    }
	
    /**
     * Load all existing frameworks from jsonfile
     * @return
     * @throws Exception
     */
	public static Map<Integer, String> loadAllFramework()throws Exception{
		int i = 1;
		Map<Integer, String> result = new HashMap<Integer, String>();
		Map<String, ProjectSetup> datas = loadProjectSetup();
		for(Map.Entry<String, ProjectSetup> sets : datas.entrySet()) {
			result.put(i, sets.getKey());
			i++;
		}
		return result;
	}
	
	/**
	 * Get the proper framework used by the user from inut
	 * @param userChoice
	 * @return
	 * @throws Exception
	 */
	public static ProjectSetup getFrameworkSetupConfig(String userChoice)throws Exception{
		ProjectSetup result = null;
		Map<String, ProjectSetup> datas = loadProjectSetup();
		result = datas.get(userChoice);
		return result;
	}
	
	/**
	 * Give the use the input and generate this project using cli
	 * @throws Exception
	 */
	public void generateProject()throws Exception{
		Scanner projectScanner = new Scanner(System.in);
		System.out.println("Project name : ");
		String project = projectScanner.nextLine();
		String cli = this.getCliGeneration();
		cli = cli.replace("?", project);
		System.out.println(cli);
		
		CommandRunner runner = new CommandRunner();
		runner.setCommand(cli);
		runner.run();
				
		String projectPath = project;
		
		this.setRoot(projectPath);
		
	}
	
	/**
	 * Get the path of the project of the one the user want to use and put the files there
	 * @throws Exception
	 */
	public void useExistingProject()throws Exception{
		String projectPath = "";
		JFileChooser fileChooser = new JFileChooser();
		fileChooser.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
		int returnal = fileChooser.showOpenDialog(fileChooser);
		if(returnal == JFileChooser.APPROVE_OPTION) {
			projectPath = fileChooser.getSelectedFile().getAbsolutePath();			
		}
		this.setRoot(projectPath);
	}
	
	public String getRoot() {
		return root;
	}
	
	public String getPath() {
		return path;
	}
	
	public String getController() {
		return controller;
	}
	
	public String getEntity() {
		return entity;
	}
	
	public String getFramework() {
		return framework;
	}
	
	public String getPackageName() {
		return packageName;
	}
	
	public String getRepository() {
		return repository;
	}
	
	public String getUrl() {
		return url;
	}
	
	public String getView() {
		return view;
	}
	
	public String getViewPath() {
		return viewPath;
	}
	
	public String getViewType() {
		return viewType;
	}
	
	public String getCliGeneration() {
		return cliGeneration;
	}
	
	public String getName() {
		return name;
	}
	
	public void setRoot(String root) {
		this.root = root;
	}
	
	public void setController(String controller) {
		this.controller = controller;
	}
	
	public void setEntity(String entity) {
		this.entity = entity;
	}
	
	public void setPackageName(String packageName) {
		this.packageName = packageName;
	}
	
	public void setFramework(String framework) {
		this.framework = framework;
	}
	
	public void setPath(String path) {
		this.path = path;
	}
	
	public void setRepository(String repository) {
		this.repository = repository;
	}
	
	public void setUrl(String url) {
		this.url = url;
	}
	
	public void setView(String view) {
		this.view = view;
	}
	
	public void setViewPath(String viewPath) {
		this.viewPath = viewPath;
	}
	
	public void setViewType(String viewType) {
		this.viewType = viewType;
	}
	
	public void setCliGeneration(String cliGeneration) {
		this.cliGeneration = cliGeneration;
	}
	
	public void setName(String name) {
		this.name = name;
	}
}
