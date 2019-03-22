package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] NumStr = scanner.nextLine().trim().split("\\s");
        String[] com = scanner.nextLine().trim().split("\\s");
        int[] nums = new int[NumStr.length];
        for (int i = 0; i < nums.length; i++) {
            nums[i] = Integer.parseInt(NumStr[i]);
        }
        int numOfelements = Integer.parseInt(com[1]);
        String oddEvene = com[2];

        if(oddEvene.toLowerCase().equals("odd")) {
            print(nums, numOfelements, 1);
        } else {
            print(nums, numOfelements, 0);
        }
    }
    private static void print(int[] nums, int numOfelements, int type) {
        for (int i = 0; i < nums.length; i++) {
            if(numOfelements == 0) {
                break;
            }

            if(nums[i] % 2 == type) {
                numOfelements--;
                System.out.print(nums[i] + " ");
            }
        }
    }
}
