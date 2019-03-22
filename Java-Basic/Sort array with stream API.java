package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] nums = scanner.nextLine().split("\\s+");
        String str = scanner.nextLine();

        if (str.equals("Ascending")){
            Arrays.stream(nums)
                    .map(d -> Integer.parseInt(d))
                    .sorted()
                    .forEach(d -> System.out.printf("%d ", d));
        }else{
            Arrays.stream(nums)
                    .map(d -> Integer.parseInt(d))
                    .sorted((d1, d2) ->d2.compareTo(d1))
                    .forEach(d -> System.out.printf("%d ", d));
        }
    }
}
