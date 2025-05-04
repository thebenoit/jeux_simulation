public class Utilitaires
{
    // Classe de m�thodes static, on ne devrait pas l'instancier
    private Utilitaires()
    {
    }

    /**
     * Donne du plus grand �l�ment dans le tableau, en commen�ant �
     * `indexDepart` (on ignore les �l�ments avant)
     */
    public static int PlusGrandElementTableau(int[] tableau, int indexDepart)
    {
        int indexMax = 0;
        int valeurMax = tableau[0];

        for (int i = indexDepart; i < tableau.Length - indexDepart; i++)
        {
            if (tableau[i] >= valeurMax)
            {
                valeurMax = tableau[i];
                indexMax = i;
            }
        }

        return indexMax;
    }
}