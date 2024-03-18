package ambovombe.kombarika.configuration.mapping;

import ambovombe.kombarika.configuration.mapping.crudMethod.MethodCrud;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class CrudMethod {
    MethodCrud findAll;
    MethodCrud findById;
    MethodCrud delete;
    MethodCrud update;
    MethodCrud save;
}
