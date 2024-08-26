using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PawsonalityApp.API.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "QuestionID", "QuestionText" },
                values: new object[,]
                {
                    { 1, "How do you prefer to spend your weekend?" },
                    { 2, "What's your approach to solving problems?" },
                    { 3, "How do you feel about meeting new people?" },
                    { 4, "What type of environment do you thrive in?" },
                    { 5, "How do you handle stressful situations?" },
                    { 6, "What's your idea of a perfect vacation?" }
                });

            migrationBuilder.InsertData(
                table: "Answer",
                columns: new[] { "AnswerID", "AnswerText", "AnswerType", "QuestionID" },
                values: new object[,]
                {
                    { 1, "Attending a social event or party", "Dog", 1 },
                    { 2, "Curled up with a good book or movie at home", "Cat", 1 },
                    { 3, "Exploring the outdoors or going on a hike", "Bird", 1 },
                    { 4, "Observing and analyzing something quietly, perhaps in a cozy corner", "Snake", 1 },
                    { 5, "Gather your friends and brainstorm together", "Dog", 2 },
                    { 6, "Think it through on your own and come up with a creative solution", "Cat", 2 },
                    { 7, "Look at the problem from different perspectives and find a high-level view", "Bird", 2 },
                    { 8, "Study the issue deeply and methodically until you find the best solution", "Snake", 2 },
                    { 9, "Excited! You love making new friends", "Dog", 3 },
                    { 10, "Cautious at first, but you warm up once you feel comfortable", "Cat", 3 },
                    { 11, "Interested, but you prefer to keep interactions light and breezy", "Bird", 3 },
                    { 12, "Selective; you prefer deep, meaningful connections over casual ones", "Snake", 3 },
                    { 13, "A bustling, lively place full of energy and activity", "Dog", 4 },
                    { 14, "A calm, quiet space where you can relax and be yourself", "Cat", 4 },
                    { 15, "An open, airy space with plenty of room to roam", "Bird", 4 },
                    { 16, "A secluded, undisturbed spot where you can focus and observe", "Snake", 4 },
                    { 17, "Lean on your friends or loved ones for support", "Dog", 5 },
                    { 18, "Retreat to your personal space to recharge and reflect", "Cat", 5 },
                    { 19, "Rise above the situation and look at it from a different perspective", "Bird", 5 },
                    { 20, "Stay calm and composed, quietly analyzing your next move", "Snake", 5 },
                    { 21, "A group trip with friends to a fun destination", "Dog", 6 },
                    { 22, "A solo retreat to a peaceful and cozy spot", "Cat", 6 },
                    { 23, "An adventure exploring new places and enjoying nature", "Bird", 6 },
                    { 24, "A quiet escape where you can immerse yourself in your surroundings", "Snake", 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Answer",
                keyColumn: "AnswerID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionID",
                keyValue: 6);
        }
    }
}
