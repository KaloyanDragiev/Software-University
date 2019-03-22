package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String inputone = scanner.nextLine();
        String[] numbersone = inputone.split(" ");
        String inputtwo = scanner.nextLine();
        String[] numberstwo = inputtwo.split(" ");
        String inputthree = scanner.nextLine();
        String[] numbersthree = inputthree.split(" ");
        int ax = Integer.parseInt(numbersone[0]);
        int ay = Integer.parseInt(numbersone[1]);
        int bx = Integer.parseInt(numberstwo[0]);
        int by = Integer.parseInt(numberstwo[1]);
        int cx = Integer.parseInt(numbersthree[0]);
        int cy = Integer.parseInt(numbersthree[1]);
        int area = (ax*(by-cy) + bx*(cy-ay) + cx*(ay-by))/2;
        if(area>0){
            System.out.println(area);
        }
        else {
            System.out.println(area*-1);
        }
    }
}
