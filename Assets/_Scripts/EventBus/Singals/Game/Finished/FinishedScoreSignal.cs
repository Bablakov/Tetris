public class FinishedScoreSignal {
    public readonly int ScoreBest;
    public readonly int Score;

    public FinishedScoreSignal(int scoreBest, int score) {
        ScoreBest = scoreBest;
        Score = score;
    }
}