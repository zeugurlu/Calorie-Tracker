
# CALORACKER

## Purpose of the Project
Dieting and losing weight are extremely difficult tasks that require prolonged focus. Eating healthy is difficult, especially when television is constantly directing you with advertisements promoting foods that will cause you to gain weight. Caloracker website aims to provide users with the best possible experience when it comes to managing their dietary and nutritional needs, whether they are focused on weight management, health improvement, or dietary tracking. It provides users a platform to simply keep track of and control their food choices. After signing up and logging in, users can easily track their eating habits and create goals. Users can input their dietary information, log their meals, and monitor their progress. In addition, Caloracker premium members receive special advantages, such as access to a variety of premium recipes and meal plans, guaranteeing that they always have access to wholesome, high-quality meal ideas. As a result, a diet tracker will be a significant step toward living a healthy life.
Requirement of the Project
1. The project must include user registration and login.
2. Users will be able to log out of the user account.
3. Users should be able to create their profiles, including personal information such as age, weight, height, and activity level.
4. Users should be able to log the calories of each food item consumed.
5. Users should be able to see the carbohydrate amount of each food item consumed.
6. Users should be able to see the protein amount of each food item consumed.
7. Users should be able to see the amount of fat in each food item consumed.
8. Calculate and display the total intake of calories, macronutrients (proteins,carbohydrates, fats), and micronutrients.
9. It allows users to set specific daily calories.
10. The user will be able to see all the meals in the system.
11. The premium user will be able to see the recipes and view the content of how this recipe is made.
12. The premium user will be able to see the calories, protein, fat, and carbohydrate amounts of the recipes.

# Libraries of the Project
1. Scaffold Identity Library

# Users of the Project
1. User
2. Premium User
3. Admin

# Functionality of the Project
1. Users can create accounts.
2. Users can log in securely.
3. Users can log out from their account.
4. Users can track their daily calorie intake and nutritional progress.
5. A unique tracker was created for each user.
6. User can edit all values of the own tracker.
7. Profile settings and customization options.
8. Normal users cannot view recipes page.
9. User sees meal data along with nutritional information, calories, protein, fat, and carbohydrates.
10. Offering recipe ideas based on users' dietary preferences and restrictions.
11. Premium user sees recipes data along with nutritional information, calories, protein, fat, and carbohydrates.
12. User can add the calories, proteins, fats, and carbohydrates the meal to the calorie tracker.
13. Premium user can add the recipes, proteins, fats, and carbohydrates the meal to the calorie tracker.
14. Premium user can see the comments of the recipes.
15. Admin can edit, create new and delete meals.
16. Admin can edit, create new and delete recipes.
17. Admin can see all the user in the system.
18. Users can view the packages to become premium user.
    
# Problems of the Project
1. It was difficult to create an empty tracker even for each user, so we could not create a daily tracker. We wrote a function that would create a new tracker for each user every 24 hours, but it did not work.
2. Premium user cannot delete, edit, or create comments. We don't know exactly why, but it doesn't work despite having all the crud controllers and views.
3. The user must be updated from the database to become premium or admin. We couldn't do it because the library we used was causing problems.
4. User cannot delete, edit, or create credit cards. We don't know exactly why, but it doesn't work despite having all the crud controllers and views.

