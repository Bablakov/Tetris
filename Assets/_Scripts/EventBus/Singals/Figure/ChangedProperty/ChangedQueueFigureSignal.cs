using System.Collections.Generic;

public class ChangedQueueFigureSignal {
    public IEnumerable<Figure> Figures;
    
    public ChangedQueueFigureSignal(IEnumerable<Figure> figures) {
        Figures = figures;
    }
}