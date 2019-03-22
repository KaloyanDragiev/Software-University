package com.company;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] input = scanner.nextLine().trim().split(" ");
        int numOfAllCards = input.length;

        Map<String, Integer> res = new LinkedHashMap<>();
        for (int i = 0; i < input.length; i++) {
            String cardFace = input[i].substring(0, input[i].length() - 1);
            if(!res.containsKey(cardFace)) {
                res.put(cardFace, 0);
            }
            res.put(cardFace, res.get(cardFace) + 1);
        }

        for (Map.Entry<String, Integer> card : res.entrySet()) {
            double percentage = ((double)card.getValue() / numOfAllCards) * 100;
            System.out.printf("%s -> %.2f%%\n", card.getKey(), percentage);
        }
    }
}
