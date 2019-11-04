package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
        System.out.println("hello world");
        BeatModelInterface model = new BeatModel();
        ControllerInterface controllerInterface = new BeatController(model);
    }





}


