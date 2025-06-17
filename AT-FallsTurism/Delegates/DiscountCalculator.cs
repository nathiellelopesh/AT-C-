namespace AT_FallsTurism.Delegates {
    public class DiscountCalculator {
        public static decimal ApplyDiscount(decimal originalPrice) {
            if (originalPrice < 0) {
                throw new ArgumentOutOfRangeException(nameof(originalPrice), "O preço não pode ser negativo.");
            }
            return originalPrice * 0.90m;
        }
    }
}
