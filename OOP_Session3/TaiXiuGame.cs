using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Session3
{
    internal class TaiXiuGame
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            GameEngine();
        }

        /// <summary>
        /// Gieo cap xuc xac cho nguoi choi 
        /// Nguoi dung se doan nho (1-5) hay lon (7-10), so 6 se duoc tinh la dat biet
        /// neu doan dung nho hoac lon thi duoc tra tien bang so tien dat cuoc, nguoc lai thi mat tien dat cuoc
        /// neu doan dung so 6 thi duoc tra tien bang 3 lan so tien dat cuoc
        /// Luc khoi dau, nguoi choi se co 1000USD, nguoi choi se dat cuoc 100USD cho moi lan choi
        /// Choi cho den khi nguoi choi het tien hoac nguoi choi muon dung choi
        /// Sau khi nguoi choi het tien hoac muon dung choi, hien thi tong so lan choi, tong so lan doan dung, tong so lan doan sai, tong so lan doan dung so 6
        /// </summary>
        static void GameEngine()
        {
            int BUDGET = 1000; //ngân quỹ
            int count = 0; //dem so lan choi
            int countCorrect = 0; //dem so lan doan dung/sai
            int countWrong = 0; //dem so lan doan sai
            //int countSix = 0; //dem so lan doan dung so 6
            PairOfDice pod = new PairOfDice();

            Console.WriteLine("WELCOME TO THE DO XI NGAU GAME");
            Console.WriteLine("-------------------------");
            do
            {
                //1. Gieo cap xuc xac
                pod.Roll();
                //2. Hoi nguoi dung doan nho hay lon
                Console.Write("Bạn đoán nhỏ (1-5) hay lớn (7-10) hay số 6 <1,2,3)? ");
                int guess;
                while (!int.TryParse(Console.ReadLine(), out guess)
                    || (guess != 1 && guess != 2 && guess != 3))
                {
                    Console.Write("Vui lòng nhập 1, 2 hoặc 3: ");
                }
                //In ra kết quả gieo xúc xắc
                Console.WriteLine($"Kết quả gieo xúc xắc:{pod} - {pod.GetPoints()}");

                //3. Kiem tra ket qua doan cua nguoi dung
                bool isCorrect = false;//giả sử người chơi đoán sai
                switch (guess)
                {
                    case 1: // đoán nhỏ
                        isCorrect = pod.GetPoints() >= 2 && pod.GetPoints() <= 5;//đoán nhỏ đúng
                        break;
                    case 2: // đoán lớn
                        isCorrect = pod.GetPoints() >= 7 && pod.GetPoints() <= 10;//đúng
                        break;
                    case 3: // đoán số 6
                        isCorrect = pod.GetPoints() == 6;
                        break;
                }

                if (isCorrect)
                {
                    Console.WriteLine("Chúc mừng! Bạn đoán đúng.");
                    countCorrect++;
                    if (guess == 3)
                    {
                        Console.WriteLine("bạn đoán đúng số 6");
                        BUDGET += 300; //đoán đúng số 6, cộng 3 lần tiền cược
                    }
                    else
                    {
                        BUDGET += 100; //đoán đúng nhỏ hoặc lớn, cộng 1 lần tiền cược
                    }
                }
                else
                {
                    Console.WriteLine("Rất tiếc! Bạn đoán sai.");
                    countWrong++;
                    BUDGET -= 100; //đoán sai, trừ 1 lần tiền cược
                }
                //xong 1 lượt chơi
                Console.WriteLine($"Số tiền trong tài khoản: {BUDGET}");
                Console.WriteLine("--------------------------");
                //nếu không đủ tiền chơi tiếp thì dừng
                if (BUDGET < 100)
                {
                    Console.WriteLine("Bạn không đủ tiền để chơi tiếp. Kết thúc trò chơi.");
                    break;
                }

                //4.  hỏi người chơi có muốn tiếp tục chơi hay không
                Console.Write("Bạn có dám tiếp tục chơi? (y/n): ");
                string continueGame = Console.ReadLine();
                if (continueGame.ToLower() != "y")
                {
                    break;
                }
            } while (true);

            //5. thong ke ket qua choi
            Console.WriteLine($"Bạn đã chơi {count} lần.");
            Console.WriteLine($"Bạn đoán đúng {countCorrect} lần.");
            Console.WriteLine($"Bạn đoán sai {countWrong} lần.");
            Console.WriteLine($"Bạn đoán đúng số 6 {count - countCorrect - countWrong} lần.");
            Console.WriteLine($"Số tiền trong tài khoản: {BUDGET}");

            Console.WriteLine("\n Bye, Lo kiếm tiền rồi chơi tiếp nhé.");
        }
    }
}
