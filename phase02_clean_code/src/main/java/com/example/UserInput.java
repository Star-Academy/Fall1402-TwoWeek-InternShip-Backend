package com.example;

import java.util.Scanner;

public class UserInput {
    private Scanner scanner;

    UserInput(){
        this.scanner = new Scanner(System.in);
    }
    
    public String getInput(String message){

        System.out.print(message);
        final String userInput = scanner.nextLine();

        return userInput;
    }

    public void closeScanner(){
        this.scanner.close();;
    }
}
