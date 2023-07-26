namespace CashRegister.Api.Models.Dfs.Enums;

//Коди результату обробки запитів документів
/// <summary>
//   Код результату обробки запита документа
/// </summary>
public enum DocumentRequestResultCode
{
    /// <summary>
    /// </summary>
    Ok = 0,

    ///<summary>
    //Документ з фіскальним номером, що відповідає режиму
    //онлайн, не зареєстрований на ПРРО
    /// </summary>
    OnlineDocumentAbsent = 1,

    /// <summary>
    //Фіскальний номер зарезервований для використання в режимі офлайн на ПРРО, але наразі ще не переданий
    /// з ПРРО до контролюючого органу
    /// </summary>
    OfflineNumberReserved = 2,

    /// <summary>
    /// Фіскальний номер не зарезервований для використання в
    // режимі офлайн на ПРРО
    /// </summary>
    OfflineNumberNotReserved = 3
}