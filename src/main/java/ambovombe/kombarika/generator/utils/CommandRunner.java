/**
 * 
 */
package ambovombe.kombarika.generator.utils;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.util.concurrent.TimeUnit;

/**
 * 
 */
public class CommandRunner {
	
	String command;
	
	public void run()throws Exception {
		boolean isWindows = isOSWindows();
		ProcessBuilder builder = new ProcessBuilder();
		if(isWindows) {
			builder.command("cmd.exe", "/c", command);
		}
		else {
			builder.command("sh", "-c", command);
		}
		
		Process process = builder.start();
		OutputStream outputStream = process.getOutputStream();
		InputStream inputStream = process.getInputStream();
		InputStream errorStream = process.getErrorStream();
		
		printStream(inputStream);
		printStream(errorStream);
		
		boolean isFinished = process.waitFor(30, TimeUnit.SECONDS);
		outputStream.flush();
		outputStream.close();
		
		if(!isFinished) {
			process.destroyForcibly();
		}
	}
	
	public void printStream(InputStream inputStream)throws Exception{
		try(BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(inputStream))) {
            String line;
            while((line = bufferedReader.readLine()) != null) {
                System.out.println(line);
            }
        }
	}
	
	public static boolean isOSWindows() {
		return System.getProperty("os.name").toLowerCase().startsWith("windows");
	}
	
	public String getCommand() {
		return command;
	}
	
	public void setCommand(String command) {
		this.command = command;
	}

}
