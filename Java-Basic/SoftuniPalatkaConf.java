package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int numberofpeople = scanner.nextInt();
        int numberofcolls = scanner.nextInt();

        scanner.nextLine();
        int total =0;
        int totalM =0;

        for (int i = 0; i < numberofcolls; i++) {
            String[] allthings = scanner.nextLine().split("\\s+");

            String something = allthings[0];
            int count = Integer.parseInt(allthings[1]);
            String type = allthings[2];

            if (something.equals("tents")) {
                if (type.equals("normal")) {
                    total += 2 * count;
                } else { // firstclass
                    total += 3 * count;
                }
            } else if (something.equals("rooms")) {
                if (type.equals("single")) {
                    total += count;
                } else if (type.equals("double")) {
                    total += 2 * count;
                } else { // tripple
                    total += 3 * count;
                }
            } else { // food
                if (type.equals("musaka")) {
                    totalM+= 2 * count;
                }
            }
        }

        if ( numberofpeople > total) {
            System.out.printf(
                    "Some people are freezing cold. Beds needed: %d%n",
                    numberofpeople - total);
        } else {
            System.out.printf(
                    "Everyone is happy and sleeping well. Beds left: %d%n",
                    total - numberofpeople);
        }
        if (numberofpeople > totalM) {
            System.out.printf(
                    "People are starving. Meals needed: %d%n",
                    numberofpeople - totalM);
        } else {
            System.out.printf(
                    "Nobody left hungry. Meals left: %d%n",
                    totalM - numberofpeople);
        }
    }
}