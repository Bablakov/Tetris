using System.Collections.Generic;

public class ChangeQueueFigureSignal {
    public IEnumerable<Figure> Figures;
    
    public ChangeQueueFigureSignal(IEnumerable<Figure> figures) {
        Figures = figures;
    }
}